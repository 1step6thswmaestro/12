var AppFlowController = require('../controller/AppFlowController');
var Constants = require('../constants/Constants');


var AppDispatcher = {
    activeApp: function() {
        AppFlowController.dispatch(
            Constants.FlowID.ACTIVE_APP,
            {}
        );
    },

    disableApp: function() {
        AppFlowController.dispatch(
            Constants.FlowID.DISABLE_APP,
            {}
        );
    }
};

module.exports = AppDispatcher;