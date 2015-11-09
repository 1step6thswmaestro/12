var DateSelector = require('./DateSelector');
var WeatherStore = require('../../stores/WeatherStore');


var TempGraphDOM;
var SunTimesDOM;
var WrapperDOM;

var dataArrays;

var leftMargin = 0;
var movedDistance = 0;

var currentSlideIndex = 0;

var TempGraph = {
    initialize: function($) {
        TempGraphDOM = $("#detail-tempGraph");
        SunTimesDOM = $('#detail-sun-times');
        WrapperDOM = $('#tempGraph-wrapper');

        this.sunArea = SunTimesDOM.find('#sun-area');
        this.sunPath = SunTimesDOM.find('#sun-path');

        this.sunRiseDescription = SunTimesDOM.find('[weather-attr=description-sun-rise]');
        this.sunSetDescription = SunTimesDOM.find('[weather-attr=description-sun-set]');

        DateSelector.addSlideChangeListener(this.moveGraph.bind(this));
    },

    initGraph: function() {
         dataArrays = (function(_this) {
            var that = _this;
            var data = (WeatherStore.getForecastData()).periods;
            var width = $(window).width();

            var _start = new Date(data[0]['dateTimeISO']);
            var _end = new Date(data[data.length - 1]['dateTimeISO']);
            var _isToday = ((_start.getDate() == (new Date()).getDate()) && (_start.getMonth() == (new Date()).getMonth() )) ? true : false;
            var _width = (function() {
                if (!_isToday) { return 1300; }
                else {
                    return 12.5 * (8 - Math.floor(_start.getHours() / 3)) + 1300;
                }
            })();
             var _windowWidth = width;
             var _leftMargin = (function() {
                if (!_isToday) { return 0; }
                else {
                    return 12.5 * (Math.floor(_start.getHours() / 3));
                }
             })();

            var _datas = [];
            for (var idx= 0, len=data.length; idx<len; idx++) {
                var __arr = [];
                __arr.push(that._convertTime((new Date(data[idx]['dateTimeISO'])).getHours()));
                __arr.push(data[idx]['maxTempC']);
                __arr.push(data[idx]['minTempC']);

                _datas.push(__arr);
            }

            return {
                startTime: _start,
                endTime: _end,
                width: _width,
                windowWidth: _windowWidth,
                leftMargin: _leftMargin,
                datas: _datas
            };
        })(this);


        leftMargin = dataArrays.leftMargin;
        var translateX = "translate3d(" + leftMargin + "%,0,0)";
        TempGraphDOM.css('transform', translateX);

        currentSlideIndex = DateSelector.getCurrentIndex();

        google.setOnLoadCallback(drawChart());

        function drawChart() {
            var data = new google.visualization.arrayToDataTable(
                [['Time', 'highTemp', 'lowTemp']].concat(dataArrays.datas)
            );

            var height = WrapperDOM.actual('height');
            var options = {
                width: (dataArrays.width / 100) * dataArrays.windowWidth,
                height: height,
                areaOpacity: 0.25,
                colors: ['#faca4e', '#63b4cf'],
                annotationText: false,
                fontSize: "1vw",
                chartArea: {width: "100%", height: '60%'},
                hAxis: {
                    textStyle: {color: '#616161', fontSize: 20}
                },
                pointsVisible: false,
                vAxis: {baselineColor: 'black', gridlines: {color: 'black'}, textStyle: { color: 'black'}},
                backgroundColor: 'black'
            };

            var chart = new google.visualization.AreaChart(document.getElementById('detail-tempGraph'));
            chart.draw(data, options);

            dataArrays = {};
        }
    },

    _convertTime: function(hour) {
        switch(hour) {
            case 0: return "00";
            case 3: return "03";
            case 6: return "06";
            case 9: return "09";
            case 12: return "12";
            case 15: return "15";
            case 18: return "18";
            case 21: return "21";
        }
    },

    moveGraph: function() {
        var newIndex = DateSelector.getCurrentIndex();

        this.resetSunPath();

        if (newIndex == 0 && DateSelector.isFirstIsTomorrow()) {
            TempGraphDOM.attr('style', 'display: none;');
            SunTimesDOM.css('opacity', 0).removeAttr('style');
            SunTimesDOM.animate({
                opacity: 1
            }, 500);

            this.animateSunPath(newIndex);
        }
        else {
            TempGraphDOM.removeAttr('style');
            SunTimesDOM.attr('style', 'display: none');

            movedDistance += ((newIndex - currentSlideIndex) * 100);
            var translateX = "translate3d(" + (leftMargin - movedDistance) + "%, 0,0)";
            TempGraphDOM.css('transform', translateX);
        }

        currentSlideIndex = newIndex;
    },

    resetSunPath: function() {
        this.sunArea.css('width', '0%');
        this.sunPath.css('transform', 'rotate3d(0,0,1,-75deg)');
    },

    animateSunPath: function(index) {
        var sunData = (WeatherStore.getSunMoonData())[index].sun;

        var sunRiseDate = new Date(sunData['riseISO']);
        var sunSetDate = new Date(sunData['setISO']);

        this.sunRiseDescription.text(
            this.__convertLeadingZeros(sunRiseDate.getHours(), 2)
            + ':'
            + this.__convertLeadingZeros(sunRiseDate.getMinutes(), 2)
        );

        this.sunSetDescription.text(
            this.__convertLeadingZeros(sunSetDate.getHours(), 2)
            + ':'
            + this.__convertLeadingZeros(sunSetDate.getMinutes(), 2)
        );

        var length = (sunSetDate.getHours() - sunRiseDate.getHours()) * 60 * 60 + (sunSetDate.getMinutes() - sunRiseDate.getMinutes()) * 60;

        var nowDate = new Date();
        var currentLength = null;

        if ((nowDate.getTime() >= sunRiseDate.getTime())
        && (nowDate.getTime() <= sunSetDate.getTime())) {
            currentLength = (nowDate.getHours() - sunRiseDate.getHours()) * 60 * 60 + (nowDate.getMinutes() - sunRiseDate.getMinutes()) * 60;
        }

        var percent = (currentLength == null) ? 100 : (currentLength / length) * 100;
        var rDeg = 75;

        if (currentLength != null) {
            var R = 33.6464758;
            var _x = 65 * percent / 100;
            var deg15 = Math.PI / 12;
            var rad2deg = 180 / Math.PI;

            var a = null;

            if (0 <= _x && _x < 50) {
                a = Math.acos(Math.cos(deg15) - _x/R) * rad2deg - 15;
            }
            else if (_x > 50) {
                a = 165 - Math.acos(_x/R - Math.cos(deg15)) * rad2deg;
            }
            else {
                a = 75;
            }

            if (a == null) throw new Error("안돼");

            rDeg = a;

            if (rDeg >= 75) rDeg = (rDeg - 75).toString();
            else rDeg = '-' + (75 - rDeg).toString();
        }

        this.sunPath.css('transform', 'rotate3d(0,0,1,' + rDeg + 'deg)');
        this.sunArea.css('width', percent + '%');
    },

    __convertLeadingZeros: function(number, digits) {
        var zero = '';
        number = number.toString();

        if (number.length < digits) {
            for (var i = 0; i < digits - number.length; i++)
                zero += '0';
        }
        return zero + number;
    }
};

module.exports = TempGraph;