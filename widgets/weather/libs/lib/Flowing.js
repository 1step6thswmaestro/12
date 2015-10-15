var Promise = require('es6-promise').Promise;
var _ = require('underscore');

var Flowing = (function() {
    function FlowController() {
        this._flows = {};
    }

    FlowController.prototype.addFlow = function addFlow(flowID) {
        var id = flowID;
        if (typeof id !== 'string') {
            throw new Error('FlowController.addFlow(...): ID is not a String.');
        }
        if (this._flows.hasOwnProperty(id)) {
            throw new Error('FlowController.addFlow(...): ' + id + ' is not a unique ID.');
        }
        this._flows[id] = _.extend({}, {
            targets: [],
            subscribes: []
        });

        return id;
    };


    FlowController.prototype.addTarget = function addTarget(id) {
        if (arguments.length == 0 || arguments.length == 1) {
            throw new Error ('FlowController.addTarget(...): Not enough Arguments.');
        }

        var id = arguments[0];
        if (typeof id !== 'string') {
            throw new Error('FlowController.addTarget(...): ID is not a String.');
        }

        var callback = arguments[1];

        if (typeof callback !== 'function') {
            throw new Error('FlowController.addTarget(...): Callback is not a Function.');
        }

        this._flows[id].targets.push(callback);
        return id;
    };


    FlowController.prototype.addSubscribe = function addSubscribe(id) {
        if (arguments.length == 0 || arguments.length == 1) {
            throw new Error ('FlowController.addSubscribe(...): Not enough Arguments.');
        }

        var id = arguments[0];

        if (typeof id !== 'string') {
            throw new Error('FlowController.addSubscribe(...): ID is not a String');
        }

        var callback = arguments[1];

        if (typeof callback !== 'function') {
            throw new Error('FlowController.addSubscribe(...): Callback is not a Function.');
        }

        this._flows[id].subscribes.push(callback);
        return id;
    };

    FlowController.prototype.deleteFlow = function deleteFlow(id) {
        if (!this._flows.hasOwnProperty(id)) {
            throw new Error('FlowController.deleteFlow(...): does not have flow which id is ' + id);
        }
        delete this._flows[id];
    };

    FlowController.prototype.dispatch = function dispatch(id, payload) {
        if (!this._flows.hasOwnProperty(id)) {
            throw new Error('FlowController.dispatch(...): does not have flow which id is ', id);
        }
        var thisFlow = this._flows[id];

        thisFlow.targets.forEach(function(target) {
            var len = thisFlow.subscribes.length;

            Promise.resolve(target(payload)).then(function() {
                for (var idx=0; idx<len; idx++) {
                    thisFlow.subscribes[idx]();
                }
            }, function() {
                throw new Error('FlowController.dispatch(...): Dispatcher callback unsuccessful');
            });

        });
    };

    FlowController.prototype.helper = {
        getFlows: function() {
            console.log('FlowController.helper.getFlows(...): ', this._flows);
            return this._flows;
        }
    };

    return FlowController;
})();

module.exports = Flowing;