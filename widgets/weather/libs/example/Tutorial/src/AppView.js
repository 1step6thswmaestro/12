var AppFlowController = require('./AppFlowController');
var AppDispatcher = require('./AppDispatcher');
var AppStore = require('./AppStore');

var SubmitButtonDOM;
var InputDOM;
var TextDOM;

var AppView = {
    initialize: function($) {
        SubmitButtonDOM = $('#SubmitButton');
        InputDOM = $('#Input');
        TextDOM = $('#Text');

        SubmitButtonDOM.on('click', function() {
            var text = InputDOM.val();
            AppDispatcher.setText(text);
        });

        InputDOM.on('keypress', function(event) {
            if (event.keyCode == 13) {
                var text = InputDOM.val();
                AppDispatcher.setText(text);
            }
        });
    },

    subscribeSetText: AppFlowController.addNotifyler(
        'FLOW_ID_1',
        function() {
            TextDOM.html(AppStore.getText());
            InputDOM.val("");
        }
    )
};

module.exports = AppView;