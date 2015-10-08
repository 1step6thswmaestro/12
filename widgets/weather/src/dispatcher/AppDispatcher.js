var Dispatcher = require('flux').Dispatcher;

var AppDispatcher = new Dispatcher();

AppDispatcher.handleClientAction = function(action) {
    this.dispatch({
        source: 'VIEW_ACTION',
        action: action
    });
};

AppDispatcher.handleAPIRequestAction = function(action) {
    this.dispatch({
        source: 'API_REQUEST_ACTION',
        action: action
    });
};

AppDispatcher.handleAPIReceiveAction = function(action) {
    this.dispatch({
        source: 'API_RECEIVE_ACTION',
        action: action
    });
};

module.exports = AppDispatcher;