var AppFlowController = require('../../controller/AppFlowController');
var AppDispatcher = require('../../dispatcher/AppDispatcher');

var WeatherStore = require('../../stores/WeatherStore');
var WeatherIcons = require('../../utils/WeatherIcons');

var Constants = require('../../constants/Constants');

var weatherData = null;
var DOM;
var AttrDOMs = {
    Icon: null,
    HighTemp: null,
    LowTemp: null,
    Description: null
};

function activeComponent() {
    DOM.removeAttr('style');
    DOM.animate({
        opacity: 1
    }, '1000', 'easeInCubic');
}

function disableComponent() {
    DOM.animate({
        opacity: 0
    }, '600', 'easeInCubic', function() {
        DOM.attr('style', 'display: none;');
    });
}

var TodayWeather = {
    initialize: function($) {
        DOM = $('section#today-weather-component');

        AttrDOMs.Icon = DOM.find('[weather-attr = today-weather-icon]');
        AttrDOMs.HighTemp = DOM.find('[weather-attr = today-weather-highTemp]');
        AttrDOMs.LowTemp = DOM.find('[weather-attr = today-weather-lowTemp]');
        AttrDOMs.Description = DOM.find('[weather-attr = today-weather-description]');

        DOM.on('click tap', function(event) {
            if (event.which == 1) { //Left Mouse Clicked
                AppDispatcher.activeApp();
            }
        });
    },

    setWeatherData: function() {
        weatherData = WeatherStore.getForecastData();
        console.log(weatherData);

        /*
        AttrDOMs.Icon.empty().append(WeatherIcons.getIconDOM(WeatherConditionConstants[weatherId][isDayOrNight]));
        AttrDOMs.HighTemp.text(parseInt(weatherData.temp['max'] - 273.15));
        AttrDOMs.LowTemp.text(parseInt(weatherData.temp['min'] - 273.15));
        AttrDOMs.Description.text(WeatherConditionConstants[weatherId]['description']);
        */
    },

    subscribeActiveApp: AppFlowController.addSubscribe(
        Constants.FlowID.ACTIVE_APP,
        function() {
            disableComponent();
        }
    )
};


module.exports = TodayWeather;