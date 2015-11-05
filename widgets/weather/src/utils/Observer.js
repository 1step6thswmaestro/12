var EventEmitter = require('events').EventEmitter;
var _ = require('underscore');


/**
 * 이 클래스는 Observer기능을 위한 유틸리티 클래스입니다.
 * 이 클래스는 IIFE방식으로 선언되어 있습니다.
 * 옵저버는 등록한 object에 대하여 관찰을 수행하고, 해당 object가 완료된 시 complete이벤트를 발생합니다.
 *
 * 옵저버 생성: new Observer()
 * object 등록: addObjects() 메소드를 수행.
 * complete 이벤트 발생: done() 메소드를 수행.
 * complete 이벤트에 리스너 등록: addCompleteListener() 메소드를 수행.
 *
 * @version 151029
 * @author 나석주
 */

var Observer = (function() {
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

    return Observer;
})();


module.exports = Observer;