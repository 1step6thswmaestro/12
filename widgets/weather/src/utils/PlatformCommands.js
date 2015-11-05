var AppDispatcher = require('../dispatcher/AppDispatcher');

var initWidget = (function (window) {
    function addExpendMethod() {
        if (window.hasOwnProperty('IsExpend')) { return; }
        window.IsExpend = function(state) {
            if (state) {
                AppDispatcher.activeApp();
            }
            else {
                AppDispatcher.disableApp();
            }
        }
    }

    return (function() {
        addExpendMethod();
    });
})(window);

module.exports = initWidget;