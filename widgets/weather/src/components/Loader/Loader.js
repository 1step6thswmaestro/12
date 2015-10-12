var AppFlowController = require('../../controller/AppFlowController');
var Constants = require('../../constants/Constants');

var AppDOM;
var LoaderDOM;

var loadedDataCount;
var requestCount;

function loadComplete() {
    if (loadedDataCount == 0) {
        loadedDataCount++;
        return;
    }

    LoaderDOM.animate({
        opacity: 0
    }, '600', 'easeInCubic');

    AppDOM.animate({
        opacity: 1
    }, '1200', 'easeInCubic');

    requestCount = 0;
}

function loadStart() {
    if (requestCount >= 1) {
        return;
    }

    loadedDataCount = 0;

    AppDOM.animate({
        opacity: 0
    }, '600', 'easeInCubic');

    LoaderDOM.animate({
        opacity: 1
    }, '1000', 'easeInCubic');

    requestCount++;
}

var Loader = {
    initialize: function($) {
        LoaderDOM = $('#loader');
        AppDOM = $('#app');

        loadedDataCount = 0;
        requestCount = 0;
    },

    callbackDispatch: AppFlowController.addTarget(
        Constants.FlowID.GET_FORECAST_DATA,
        function() {
            loadStart();
        }
    ),

    notifyForecastData: AppFlowController.addNotifyler(
        Constants.FlowID.GET_FORECAST_DATA,
        function() {
            loadComplete(Constants.FlowID.GET_FORECAST_DATA);
        }
    ),

    notifySunMoonData: AppFlowController.addNotifyler(
        Constants.FlowID.GET_SUN_MOON_DATA,
        function() {
            loadComplete(Constants.FlowID.GET_SUN_MOON_DATA);
        }
    )
};

module.exports = Loader;