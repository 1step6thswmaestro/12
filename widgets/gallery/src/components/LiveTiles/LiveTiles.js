var Flowing = require('../../controller/AppFlowController');
var Constants = require('../../constants/Constants');

function activeComponent() {
    Screen
        .removeAttr('style')
        .css('opaicty', 0)
        .animate({
            opacity: 1
        }, 650, 'swing');
}

function disableComponent() {
    Screen
        .animate({
            opacity: 0
        }, 650, 'swing', function() {
           Screen.attr('style', "display: none;");
        });
}



var Screen;
var DOM;


/**
 * 이 클래스는 LiveTiles 컴포넌트입니다.
 *
 * initialize(): 이 클래스를 초기화합니다. DOM 객체를 저장합니다.
 *
 * @version 151108
 * @author 나석주
 */
var LiveTiles = {
    initialize: function($) {
        Screen = $('#SCREEN_NORMAL');
        DOM = $('#component-image-slider');
    },

    activeApp: Flowing.addSubscribe(
        Constants.FlowID.ACTIVE_APP,
        function() {
            disableComponent();
        }
    ),

    disableApp: Flowing.addSubscribe(
        Constants.FlowID.DISABLE_APP,
        function() {
            activeComponent();
        }
    )
};

module.exports = LiveTiles;
