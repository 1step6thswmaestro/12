var AppFlowController = require('./AppFlowController');
var Promise = require('flowing-js').Promise;

var _text = "";

function setText(text) {
    _text += (text + '<br />');
}

var AppStore = {
    getText: function() {
        return _text;
    },

    setText: AppFlowController.addTarget(
        'FLOW_ID_1',
        function(payload) {
            return new Promise(function(resolve, reject) {
                setText(payload.text);
                resolve();
            });
        }
    )
};

module.exports = AppStore;