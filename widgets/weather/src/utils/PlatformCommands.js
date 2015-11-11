var AppDispatcher = require('../dispatcher/AppDispatcher');


/**
 * 이 클래스는 플랫폼의 API를 정의한 클래스입니다.
 * 이 클래스는 플랫폼이 사용가능한 IsExpend(@param) 메소드를 window 객체에 등록합니다.
 * IsExpand(@param) - @param이 true일 경우, Widget을 Active 상태로 바꿉니다.
 *                  - @param이 false일 경우, Widget을 Disable 상태로 바꿉니다.
 *
 * @version 151101
 * @author 나석주
 */
var initWidget = (function (window) {
    function addExpendMethod() {
        if (window.hasOwnProperty('IsExpand')) { return; }
        window.IsExpand = function(state) {
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