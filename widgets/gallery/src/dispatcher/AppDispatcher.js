var AppFlowController = require('../controller/AppFlowController');
var Constants = require('../constants/Constants');


/**
 * 이 클래스는 액션 발생기 - Dispatcher의 메소드를 정의한 클래스입니다.
 * 이 클래스는 액션의 흐름을 정의하고, 액션의 인터페이스를 정의합니다.
 *
 *
 * @version 151028
 * @author 나석주
 */
var AppDispatcher = {
    activeApp: function() {
        AppFlowController.dispatch(
            Constants.FlowID.ACTIVE_APP,
            {}
        );
    },

    disableApp: function() {
        AppFlowController.dispatch(
            Constants.FlowID.DISABLE_APP,
            {}
        );
    }
};

module.exports = AppDispatcher;
