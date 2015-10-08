var EventEmitter = require('events').EventEmitter;
var _ = require('underscore');


function Observer() {
    this.emitor = _.extend({}, EventEmitter.prototype);

    this.objects = [];
    this.stack = [];

    for (var idx=0; idx<arguments.length; idx++) {
        this.objects.push(arguments[idx]);
        this.stack.push(false);
    }
}


Observer.prototype.addObjects = function() {
    for (var idx=0; idx<arguments.length; idx++) {
        this.objects.push(arguments[idx]);
        this.stack.push(false);
    }
};

Observer.prototype.done = function(object) {
    for (var idx=0; idx<this.objects.length; idx++) {
        if (this.objects[idx] == object) {
            this.stack[idx] = true;
        }
    }

    for (var idx=0; idx<this.stack.length; idx++) {
        if (this.stack[idx] == false) return;
    }
    this.emitor.emit('complete');
};

Observer.prototype.addCompleteListener = function(callback) {
    this.emitor.addListener('complete', callback);
};

Observer.prototype.removeCompleteListener = function(callback) {
    this.emitor.removeListener('complete', callback);
};



module.exports = Observer;