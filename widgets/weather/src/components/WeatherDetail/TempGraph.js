var DateSelector = require('./DateSelector');

var WeatherStore = require('../../stores/WeatherStore');


var TempGraphDOM;
var WrapperDOM;

var dataArrays

var leftMargin = 0;
var movedDistance = 0;

var currentSlideIndex = 0;

var TempGraph = {
    initialize: function($) {
        TempGraphDOM = $("#detail-tempGraph");
        WrapperDOM = $('#tempGraph-wrapper');

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
        var translateX = "translateX(" + leftMargin + "%)"; //TODO: Not Working
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

        movedDistance += ((newIndex - currentSlideIndex) * 100);
        var translateX = "translateX(" + (leftMargin - movedDistance) + "%)";
        TempGraphDOM.css('transform', translateX);

        currentSlideIndex = newIndex;
    }
};

module.exports = TempGraph;