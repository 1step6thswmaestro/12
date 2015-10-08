var AppDispatcher = require('../dispatcher/AppDispatcher');
var Constants = require('../constants/Constants');
var API = require('../apis/API');


var APIActionCreator = {
    requestForecastData: function() {
        AppDispatcher.handleAPIRequestAction({
            actionType: Constants.ActionType.REQUEST_FORECAST_DATA
        });
        API.getForecastData();
    },

    requestSunMoonData: function() {
        AppDispatcher.handleAPIRequestAction({
            actionType: Constants.ActionType.REQUEST_SUN_MOON_DATA
        })
    },

    receiveForecastData: function(_forecastData) {
        AppDispatcher.handleAPIReceiveAction({
            actionType: Constants.ActionType.RECEIVE_FORECAST_DATA,
            forecastData: _forecastData
        });
    }
};

module.exports = APIActionCreator;