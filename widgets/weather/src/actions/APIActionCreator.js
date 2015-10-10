var AppDispatcher = require('../dispatcher/AppDispatcher');
var Constants = require('../constants/Constants');
var API = require('../apis/API');


var APIActionCreator = {
    requestForecastData: function(dataAmount) {
        AppDispatcher.handleAPIRequestAction({
            actionType: Constants.ActionType.REQUEST_FORECAST_DATA
        });
        API.getForecastData(dataAmount);
    },

    requestSunMoonData: function() {
        AppDispatcher.handleAPIRequestAction({
            actionType: Constants.ActionType.REQUEST_SUN_MOON_DATA
        });
        API.getSunMoonData();
    },

    receiveForecastData: function(_forecastData) {
        AppDispatcher.handleAPIReceiveAction({
            actionType: Constants.ActionType.RECEIVE_FORECAST_DATA,
            forecastData: _forecastData
        });
    },

    receiveSunMoonData: function(_sunmoonData) {
        AppDispatcher.handleAPIReceiveAction({
            actionType: Constants.ActionType.RECEIVE_SUN_MOON_DATA,
            sunmoonData: _sunmoonData
        });
    }
};

module.exports = APIActionCreator;