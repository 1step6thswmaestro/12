var AppFlowController = require('../../controller/AppFlowController');
var AppDispatcher = require('../../dispatcher/AppDispatcher');
var Constants = require('../../constants/Constants');

var AppDOM;
var LoaderDOM;
var loadedDataCount;

function loadComplete() {
    if (loadedDataCount == 0) {
        loadedDataCount++;
        return;
    }

    LoaderDOM.animate({
        opacity: 0
    }, '600', 'easeInCubic');

    AppDOM.removeAttr('style');
    AppDOM.animate({
        opacity: 1
    }, '1200', 'easeInCubic');
}

var Loader = {
    initialize: function($) {
        LoaderDOM = $('#loader');
        AppDOM = $('#app');
        loadedDataCount = 0;
    },

    loadStart: function() {
        loadedDataCount = 0;
        AppDispatcher.getForecastData(114);
        AppDispatcher.getSunMoonData();
    },

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