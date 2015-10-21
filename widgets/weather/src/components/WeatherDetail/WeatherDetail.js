var AppFlowController = require('../../controller/AppFlowController');
var Constants = require('../../constants/Constants');

var DateSelector = require('./DateSelector');
var TempGraph = require('./TempGraph');

var DayWeatherDetail = require('./MainDetail/DayWeatherDetail');
var DayWeatherHeader = require('./MainDetail/DayWeatherHeader');
var SunAndMoon = require('./MainDetail/SunAndMoon');
var WindAndPressure = require('./MainDetail/WindAndPressure');


var countCallback = 0;

function setDataOfIndex(index) {

}

function initializeDatas() {
    if (countCallback == 0) {
        countCallback++;
        return;
    }

    //TempGraph.initGraph();
    //DateSelector.initItems();

    setDataOfIndex(0);

    countCallback = 0;
}


var WeatherDetail = {
    initialize: function($) {
        countCallback = 0;

        DateSelector.initialize($);
        TempGraph.initialize($);

        DayWeatherDetail.initialize($);
        DayWeatherHeader.initialize($);
        SunAndMoon.initialize($);
        WindAndPressure.initialize($);
    },

    subscribeForecastData: AppFlowController.addSubscribe(
        Constants.FlowID.GET_FORECAST_DATA,
        function() {
            initializeDatas();
        }
    ),

    subscribeSunMoonData: AppFlowController.addSubscribe(
        Constants.FlowID.GET_SUN_MOON_DATA,
        function() {
            initializeDatas();
        }
    )
};

module.exports = WeatherDetail;