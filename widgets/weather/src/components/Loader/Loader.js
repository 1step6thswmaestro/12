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
    }, '600', 'easeInCubic', function() {
        LoaderDOM.attr('style', 'display: none;');
    });

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
    LoaderDOM.removeAttr('style');

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

    loadStart: function() {
        loadStart();
    },

    subscribeForecastData: AppFlowController.addSubscribe(
        Constants.FlowID.GET_FORECAST_DATA,
        function() {
            loadComplete(Constants.FlowID.GET_FORECAST_DATA);
        }
    ),

    subscribeSunMoonData: AppFlowController.addSubscribe(
        Constants.FlowID.GET_SUN_MOON_DATA,
        function() {
            loadComplete(Constants.FlowID.GET_SUN_MOON_DATA);
        }
    )
};

module.exports = Loader;