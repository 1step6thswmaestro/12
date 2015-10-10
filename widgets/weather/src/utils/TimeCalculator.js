var APIActionCreator = require('../actions/APIActionsCreator');
var Observer = require('./Observer');


var SECONDS_OF_3HOUR = 3 * 60 * 60;
var DATA_AMOUNT_OF_2WEEKS = 104; //2주치 데이터 (8 x 14)

var TimeCalculator = {
    initialize: function() {
        this.setTimer();
    },

    setTimer: function() {
        var dataAmount = (7 - parseInt((new Date).getHours() / 3)) + DATA_AMOUNT_OF_2WEEKS;
        setTimeout(function() {
            this.callAPI(dataAmount);
            this.setTimer();
        }.bind(this), SECONDS_OF_3HOUR);
    },

    callAPI: function(dataAmount) {
        APIActionCreator.requestForecastData(dataAmount);
        APIActionCreator.requestSunMoonData();
    }
};

module.exports = TimeCalculator;