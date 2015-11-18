var WeatherIcons = require('../../../utils/WeatherIcons');
var CodedWeather = require('../../../constants/CodedWeather');
var WeatherCodeUtil = require('../../../utils/WeatherCodeUtil');

var DateSelector = require('../DateSelector');
var WeatherStore = require('../../../stores/WeatherStore');

var _ = require('underscore');


var DOM;
var texts = {
    'detail-highTemp': 0,
    'detail-lowTemp': 0
};


/**
 * 이 클래스는 DayWeatherHeader 컴포넌트입니다.
 *
 * initialize(): 이 클래스를 초기화합니다. DOM 객체를 저장합니다.
 * displayContext(): 컴포넌트에 날씨 정보를 표시합니다.
 *
 * @version 151106
 * @author 나석주
 */
var DayWeatherHeader = {
    initialize: function($) {
        DOM = $('#day-weather-header');

        this.icon = DOM.find('[weather-attr=detail-icon]');
        this.highTemp = DOM.find('[weather-attr=detail-highTemp]');
        this.lowTemp = DOM.find('[weather-attr=detail-lowTemp]');
        this.description = DOM.find('[weather-attr=detail-description]');

        DateSelector.addSlideChangeListener(this.displayContext.bind(this));
    },

    displayContext: function() {
        var index = DateSelector.getCurrentIndex();
        var data = (WeatherStore.getTwoWeeksData()).periods[index];

        this._displayIcon(data);
        this._displayTemp(data);
        this._displayDescription(data);
    },

    _displayIcon: function(data) {
        var iconDOM = WeatherIcons.getIconDOM(CodedWeather.Icons[data['icon']]).clone();

        this.icon.animate({
            opacity: 0
        }, 250, 'easeInCubic', function() {
            this.icon.empty().append(iconDOM);
            this.icon.animate({opacity: 1}, 300, 'easeInCubic');
        }.bind(this));
    },

    _displayTemp: function(data) {
        var options = {
            useEasing : true,
            useGrouping : true,
            separator : ',',
            decimal : '.',
            prefix : '',
            suffix : ''
        };
        var countHighTemp = new CountUp('detail-highTemp', texts['detail-highTemp']*=1, data['maxTempC']*=1, 0, 3.5, options);
        var countLowTemp = new CountUp('detail-lowTemp', texts['detail-lowTemp']*=1, data['minTempC']*=1, 0, 3.5, options);

        countHighTemp.start();
        countLowTemp.start();

        texts['detail-highTemp'] = data['maxTempC'];
        texts['detail-lowTemp'] = data['minTempC'];
    },

    _displayDescription: function(data) {
        this.description.text(WeatherCodeUtil.getForecastText(data['weatherPrimaryCoded']));
    }
};

module.exports = DayWeatherHeader;
