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

var LiveTiles = {
    initialize: function($) {
        Screen = $('#SCREEN_NORMAL');
        DOM = $('#component-image-slider');
    },

    activeApp: Flowing.addSubscribe(
        Constants.FlowID.ACTIVE_APP,
        function() {
            console.log("active");
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