var AppFlowController = require('../../controller/AppFlowController');
var Constants = require('../../constants/Constants');

var PlatformCommands = require('../../utils/PlatformCommands');

var AppDOM;
var LoaderDOM;

var loadedDataCount;
var requestCount;

function loadComplete() {
    if (loadedDataCount == 0 || loadedDataCount == 1) {
        loadedDataCount++;
        return;
    }

    LoaderDOM.animate({
        opacity: 0
    }, '600', 'easeInCubic', function () {
        LoaderDOM.attr('style', 'display: none;');
    });

    AppDOM.animate({
        opacity: 1
    }, '1200', 'easeInCubic');

    requestCount = 0;
    PlatformCommands();
}


var Loader = {
    initialize: function($) {
        LoaderDOM = $('#loader');
        AppDOM = $('#app');

        loadedDataCount = 0;
        requestCount = 0;
    },

    loadStart: function() {
        loadedDataCount = 0;
        LoaderDOM.removeAttr('style');

        AppDOM.animate({
            opacity: 0
        }, '600', 'easeInCubic');

        LoaderDOM.animate({
            opacity: 1
        }, '1000', 'easeInCubic');

        requestCount++;
    },

    subscribeForecastData: AppFlowController.addSubscribe(
        Constants.FlowID.GET_FORECAST_DATA,
        function() {
            loadComplete(Constants.FlowID.GET_FORECAST_DATA);
        }
    ),

    subscribeTwoWeeksData: AppFlowController.addSubscribe(
        Constants.FlowID.GET_14_FORECAST_DATA,
        function() {
            loadComplete(Constants.FlowID.GET_14_FORECAST_DATA);
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