var AppFlowController = require('../../controller/AppFlowController');
var AppDispatcher = require('../../dispatcher/AppDispatcher');

var WeatherStore = require('../../stores/WeatherStore');
var WeatherCodeUtil = require('../../utils/WeatherCodeUtil');
var WeatherIcons = require('../../utils/WeatherIcons');

var Constants = require('../../constants/Constants');
var CodedWeather = require('../../constants/CodedWeather');


var DOM;
var countCallback = 0;

function initializeDatas() {
    if (countCallback == 0 || countCallback == 1) {
        countCallback++;
        return;
    }

    TodayWeather.setWeatherData();
    countCallback = 0;
}

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

        this.Icon = DOM.find('[weather-attr = today-weather-icon]');
        this.HighTemp = DOM.find('[weather-attr = today-weather-highTemp]');
        this.LowTemp = DOM.find('[weather-attr = today-weather-lowTemp]');
        this.Description = DOM.find('[weather-attr = today-weather-description]');
    },

    setWeatherData: function() {
        var data = (WeatherStore.getForecastData()).periods[0];

        this.Icon.empty().append(WeatherIcons.getIconDOM(CodedWeather.Icons[data['icon']]).clone());
        this.HighTemp.text(data['maxTempC']);
        this.LowTemp.text(data['minTempC']);
        this.Description.text(WeatherCodeUtil.getForecastText(data['weatherPrimaryCoded']));
    },

    subscribeForecastData: AppFlowController.addSubscribe(
        Constants.FlowID.GET_FORECAST_DATA,
        function() {
            initializeDatas();
        }
    ),

    subscribeTwoWeeksData: AppFlowController.addSubscribe(
        Constants.FlowID.GET_14_FORECAST_DATA,
        function() {
            initializeDatas();
        }
    ),

    subscribeSunMoonData: AppFlowController.addSubscribe(
        Constants.FlowID.GET_SUN_MOON_DATA,
        function() {
            initializeDatas();
        }
    ),

    subscribeActiveApp: AppFlowController.addSubscribe(
        Constants.FlowID.ACTIVE_APP,
        function() {
            disableComponent();
        }
    ),

    subscribeDisableApp: AppFlowController.addSubscribe(
        Constants.FlowID.DISABLE_APP,
        function() {
            activeComponent();
        }
    )
};


module.exports = TodayWeather;