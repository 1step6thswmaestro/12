var AppFlowController = require('../../controller/AppFlowController');
var Constants = require('../../constants/Constants');

var DateSelector = require('./DateSelector');
var TempGraph = require('./TempGraph');

var DayWeatherDetail = require('./MainDetail/DayWeatherDetail');
var DayWeatherHeader = require('./MainDetail/DayWeatherHeader');
var SunAndMoon = require('./MainDetail/SunAndMoon');
var WindAndPressure = require('./MainDetail/WindAndPressure');


var DOM;

function activeComponent() {
    console.log("active");
    DOM.removeAttr('style');
    DOM.css('opacity', 0);

    setTimeout(function() {
        DateSelector.initSlider();
        TempGraph.initGraph();

        DOM.animate({
            opacity: 1
        }, 500);
    }, 500);

}

function disableComponent() {
    DOM.animate({
        opacity: 0
    }, 500, function() {
        DOM.attr('style', 'display: none;');
    });
}

/**
 * 이 클래스는 WeatherDetail 컴포넌트입니다.
 * 이 클래스는 Widget이 Active 상태가 되었을 때 호출됩니다.
 *
 * @version 151110
 * @author 나석주
 */

var WeatherDetail = {
    initialize: function($) {
        DOM = $('section#weather-detail-component');

        DateSelector.initialize($);
        TempGraph.initialize($);

        DayWeatherDetail.initialize($);
        DayWeatherHeader.initialize($);
        SunAndMoon.initialize($);
        WindAndPressure.initialize($);
    },


    subscribeActiveApp: AppFlowController.addSubscribe(
        Constants.FlowID.ACTIVE_APP,
        function() {
            activeComponent();
        }
    ),

    subscribeDisableApp: AppFlowController.addSubscribe(
        Constants.FlowID.DISABLE_APP,
        function() {
            disableComponent();
        }
    )
};

module.exports = WeatherDetail;
