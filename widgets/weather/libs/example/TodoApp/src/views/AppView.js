var AppFlowController = require('../controller/AppFlowController');
var AppDispatcher = require('../dispatcher/AppDispatcher');
var AppStore = require('../stores/Appstore');

var buttonDOM;
var textDOM;

var AppView = {
    initialize: function($) {
        buttonDOM = $('#my_button');
        textDOM = $('#my_text');

        buttonDOM.on('click tap', function() {
            AppDispatcher.exampleAction();
            AppDispatcher.hohhohooh();
        });
    },

    notifyDispatch: AppFlowController.addNotifyler('ID_1', function() {
        console.log("notify Dispatched");
        textDOM.text(AppStore.getText());
    }),

    hang: AppFlowController.addNotifyler('ID_2', function() {
        console.log("halo");
    })
};



module.exports = AppView;