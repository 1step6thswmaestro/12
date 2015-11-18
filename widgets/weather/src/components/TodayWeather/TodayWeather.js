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
}

function disableComponent() {
    DOM.attr('style', 'display: none;');
}

/**
 * 이 클래스는 TodayWeather 컴포넌트입니다.
 *
 * initialize(): 이 클래스를 초기화합니다.
 * setWeatherData(): 컴포넌트에 날씨 정보를 표시합니다.
 *
 * @version 151028
 * @author 나석주
 */
var TodayWeather = {
    initialize: function($) {
        DOM = $('section#today-weather-component');

        this.Icon = DOM.find('[weather-attr = today-weather-icon]');
        this.HighTemp = DOM.find('[weather-attr = today-weather-highTemp]');
        this.LowTemp = DOM.find('[weather-attr = today-weather-lowTemp]');
        this.Description = DOM.find('[weather-attr = today-weather-description]');
    },

    setWeatherData: function() {
        var data = (WeatherStore.getTwoWeeksData()).periods[0];

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
