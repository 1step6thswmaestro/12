var AppDispatcher = require('../dispatcher/AppDispatcher');
var Constants = require('../constants/Constants');
var EventEmitter = require('events').EventEmitter;
var _ = require('underscore');


var ForecastData;
var SunMoonData;

function initForecastData(_weatherData) {
    ForecastData = _weatherData;
    console.log("WeatherData", ForecastData);
}

function initSunMoonData(_sunMoonData) {
    SunMoonData = _sunMoonData;
}


var WeatherStore = _.extend({}, EventEmitter.prototype, {
    getForecastData: function() {
        return ForecastData;
    },

    emitReceiveData: function() { this.emit('received'); },
    addReceiveDataListener: function(callback) { this.on('received', callback); },
    removeReceiveDataListener: function(callback) { this.removeListener('received', callback); }
});


AppDispatcher.register(function(payload) {
    var action = payload.action;

    switch(action.actionType) {
        case Constants.ActionType.RECEIVE_FORECAST_DATA:
            initForecastData(action.forecastData);
            WeatherStore.emitReceiveData();
            break;

        case Constants.ActionType.RECEIVE_SUN_MOON_DATA:
            initSunMoonData(action.sunMoonData);
            WeatherStore.emitReceiveData();
            break;

        default:
            return true;
    }
});

module.exports = WeatherStore;