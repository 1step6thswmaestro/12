var AppDispatcher = require('../dispatcher/AppDispatcher');
var Loader = require('../components/Loader/Loader');

var SECONDS_OF_3HOUR = 3 * 60 * 60;
var DATA_AMOUNT_OF_2WEEKS = 104; //2주치 데이터 (8 x 14)

var TimeCalculator = {
    initialize: function() {
        this.dispatchAction(8 - Math.floor((new Date).getHours() / 3) + DATA_AMOUNT_OF_2WEEKS);
        this.setTimer();
    },

    setTimer: function() {
        var dataAmount = (8 - Math.floor((new Date).getHours() / 3)) + DATA_AMOUNT_OF_2WEEKS;
        setTimeout(function() {
            this.dispatchAction(dataAmount);
            this.setTimer();
        }.bind(this), SECONDS_OF_3HOUR * 1000);
    },

    dispatchAction: function(dataAmount) {
        Loader.loadStart();
        AppDispatcher.getForecastData(dataAmount);
        AppDispatcher.getTwoWeeksData();
        AppDispatcher.getSunMoonData();
    }
};

module.exports = TimeCalculator;