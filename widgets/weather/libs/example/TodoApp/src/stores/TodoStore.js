var AppFlowController = require('../controller/AppFlowController');
var TodoConstants = require('../constants/TodoConstants');
var _ = require('underscore');
var Promise = require('es6-promise').Promise;


var _todos = {};


function create(text) {
    var id = (+new Date() + Math.floor(Math.random() * 999999)).toString(36);
    _todos[id] = {
        id: id,
        complete: false,
        text: text
    };
}

function update(id, updates) {
    _todos[id] = _.extend({}, _todos[id], updates);
}

function updateAll(updates) {
    for (var id in _todos) {
        update(id, updates);
    }
}

function destroy(id) {
    delete _todos[id];
}

function destroyCompleted() {
    for (var id in _todos) {
        if (_todos[id].complete) {
            destroy(id);
        }
    }
}



var AppStore = {
    areAllComplete: function() {
        for (var id in _todos) {
            if (!_todos[id].complete) {
                return false;
            }
        }
        return true;
    },

    getAll: function() {
        return _todos;
    },



    /*
     *  It is not essential to make Promise Object.
     *  You can pass just function for the AppFlowController.addNotifyler(...) factor.
     *  But I recommend pass the Promise Object because it can defined the location when the action notifyed.
     *
     *  반드시 Promise 객체를 넘길 필요는 없습니다 단순한 함수를 인자로 넘겨도 상관 없습니다
     *  하지만 Promise 객체를 넘기면 notify가 되는 곳을 확실하게 정할 수 있기 때문에 Promise 객체를 넘기는 것을 추천합니다
     *
     */
    callbackCreateTodo: AppFlowController.addTarget(
        TodoConstants.TodoFlowID.TODO_CREATE,
        function(payload) {
            return new Promise(function(resolve, reject) {
                text = payload.text.trim();
                if (text !== '') {
                    create(text);
                }
                resolve();
            });
        }
    ),

    callbackToggleCompleteAll: AppFlowController.addTarget(
        TodoConstants.TodoFlowID.TODO_TOGGLE_COMPLETE_ALL,
        function() {
            return new Promise(function(resolve, reject) {
                if (AppStore.areAllComplete()) {
                    updateAll({complete: false});
                } else {
                    updateAll({complete: true});
                }
                resolve();
            });
        }
    ),

    callbackUndoComplete: AppFlowController.addTarget(
        TodoConstants.TodoFlowID.TODO_UNDO_COMPLETE,
        function(payload) {
            return new Promise(function(resolve, reject) {
                update(payload.id, {complete: false});
                resolve();
            });
        }
    ),

    callbackTodoComplete: AppFlowController.addTarget(
        TodoConstants.TodoFlowID.TODO_COMPLETE,
        function(payload) {
            return new Promise(function(resolve, reject) {
                update(payload.id, {complete: true});
                resolve();
            });
        }
    ),

    callbackTodoUpdateText: AppFlowController.addTarget(
        TodoConstants.TodoFlowID.TODO_UPDATE_TEXT,
        function(payload) {
            return new Promise(function(resolve, reject) {
                text = payload.text.trim();
                if (text !== '') {
                    update(payload.id, {text: text});
                }
                resolve();
            });
        }
    ),

    callbackTodoDestroy: AppFlowController.addTarget(
        TodoConstants.TodoFlowID.TODO_DESTROY,
        function(payload) {
            return new Promise(function(reslove, reject) {
                destroy(payload.id);
                reslove();
            });
        }
    ),

    callbackTodoDestroyComplete: AppFlowController.addTarget(
        TodoConstants.TodoFlowID.TODO_DESTROY_COMPLETED,
        function() {
            return new Promise(function(resolve, reject) {
                destroyCompleted();
                resolve();
            });
        }
    )
};




module.exports = AppStore;