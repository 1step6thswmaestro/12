var AppFlowController = require('./AppFlowController');

var AppDispatcher = {
    setText: function(text) {
        AppFlowController.dispatch(
            'FLOW_ID_1',
            { text: text }
        );
    }
};

module.exports = AppDispatcher;