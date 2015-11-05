var AppDispatcher = require('../dispatcher/AppDispatcher');
var Loader = require('../components/Loader/Loader');

var SECONDS_OF_3HOUR = 3 * 60 * 60;
var DATA_AMOUNT_OF_2WEEKS = 104; //2주치 데이터 (8 x 14)

function setTimer() {
    var dataAmount = (8 - Math.floor((new Date).getHours() / 3)) + DATA_AMOUNT_OF_2WEEKS;
    setTimeout(function() {
        dispatchAction(dataAmount);
        setTimer();
    }.bind(this), SECONDS_OF_3HOUR * 1000);
}

function dispatchAction(dataAmount) {
    Loader.loadStart();
    AppDispatcher.getForecastData(dataAmount);
    AppDispatcher.getTwoWeeksData();
    AppDispatcher.getSunMoonData();
}


/**
 * 이 클래스는 3시간 간격으로 날씨 API를 호출하기 위한 유틸리티 클래스입니다.
 *
 * initialize(): 이 클래스를 초기화하고 API호출 및 타이머를 작동시킵니다.
 *
 * @version 151028
 * @author 나석주
 */
var TimeCalculator = {
    initialize: function() {
        dispatchAction(8 - Math.floor((new Date).getHours() / 3) + DATA_AMOUNT_OF_2WEEKS);
        setTimer();
    }
};

module.exports = TimeCalculator;