var Flowing = require('../controller/AppFlowController');
var Constants = require('../constants/Constants');

var Promise = require('flowing-js').Promise;

var PictureStore = {
    activeApp: Flowing.addTarget(
        Constants.FlowID.ACTIVE_APP,
        function() {
            return new Promise(function(resolve, reject) {
                resolve();
            });
        }
    ),

    disableApp: Flowing.addTarget(
        Constants.FlowID.DISABLE_APP,
        function() {
            return new Promise(function(resolve, reject) {
                resolve();
            });
        }
    )
};

module.exports = PictureStore;