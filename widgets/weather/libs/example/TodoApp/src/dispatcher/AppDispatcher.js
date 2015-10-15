var AppFlowController = require('../controller/AppFlowController');
var Constants = require('../constants/Constants');

var AppDispatcher = {
    create: function(text) {
        AppFlowController.dispatch(
            Constants.TodoFlowID.TODO_CREATE,
            {text: text}
        );
    },

    updateText: function(id, text) {
        AppFlowController.dispatch(
            Constants.TodoFlowID.TODO_UPDATE_TEXT,
            {id: id, text: text}
        );
    },

    toggleComplete: function(todo) {
        var id = todo.id;
        var FlowID = todo.complete ?
            Constants.TodoFlowID.TODO_UNDO_COMPLETE :
            Constants.TodoFlowID.TODO_COMPLETE;

        AppFlowController.dispatch(
            FlowID,
            {id: id}
        );
    },

    toggleCompleteAll: function() {
        AppFlowController.dispatch(
            Constants.TodoFlowID.TODO_TOGGLE_COMPLETE_ALL,
            {}
        );
    },

    destroy: function(id) {
        AppFlowController.dispatch(
            Constants.TodoFlowID.TODO_DESTROY,
            {id: id}
        );
    },

    destroyCompleted: function() {
        AppFlowController.dispatch(
            Constants.TodoFlowID.TODO_DESTROY_COMPLETED,
            {}
        );
    }
};

module.exports = AppDispatcher;