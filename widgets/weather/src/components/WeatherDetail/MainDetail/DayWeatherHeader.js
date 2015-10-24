var WeatherIcons = require('../../../utils/WeatherIcons');
var CodedWeather = require('../../../constants/CodedWeather');
//var WeatherCodeUtil = require('../../utils/WeatherCodeUtil');

var DateSelector = require('../DateSelector');
var WeatherStore = require('../../../stores/WeatherStore');

var _ = require('underscore');


var DOM;

var DayWeatherHeader = {
    initialize: function($) {
        DOM = $('#day-weather-header');

        this.icon = DOM.find('[weather-attr=detail-icon]');
        this.highTemp = DOM.find('[weather-attr=highTemp]');
        this.lowTemp = DOM.find('[weather-attr=lowTemp]');
        this.description = DOM.find('[weather-attr=description]');

        DateSelector.addSlideChangeListener(this.displayContext.bind(this));
    },

    displayContext: function() {
        var index = DateSelector.getCurrentIndex();

        if (index == 0) { this._contextForToday(); }
        else { this._contextForOtherDays(); }
    },

    _contextForToday: function() {
        var data = (WeatherStore.getForecastData()).periods[0];

        var iconDOM = WeatherIcons.getIconDOM(CodedWeather.Icons[data['icon']]).clone();
        this.icon.empty().append(iconDOM);
        this.highTemp.text(data['maxTempC']);
        this.lowTemp.text(data['minTempC']);
    },

    _contextForOtherDays: function() {
        
    }
};

module.exports = DayWeatherHeader;