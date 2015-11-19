var FlowController = require('flowing-js').FlowController;
var Constants = require('../constants/Constants');

/**
 * 이 클래스는 데이터 플로우를 컨트롤하기 위한 클래스입니다.
 * 이 클래스는 main 모듈이 실행 시 초기화됩니다.
 *
 * @version 151026
 * @author 나석주
 */
var AppFlowController = new FlowController();

AppFlowController.addFlow(Constants.FlowID.LOAD_PICTURES);
AppFlowController.addFlow(Constants.FlowID.ACTIVE_APP);
AppFlowController.addFlow(Constants.FlowID.DISABLE_APP);

module.exports = AppFlowController;
