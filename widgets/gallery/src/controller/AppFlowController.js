var FlowController = require('flowing-js').FlowController;
var Constants = require('../constants/Constants');

var AppFlowController = new FlowController();

AppFlowController.addFlow(Constants.FlowID.LOAD_PICTURES);
AppFlowController.addFlow(Constants.FlowID.ACTIVE_APP);
AppFlowController.addFlow(Constants.FlowID.DISABLE_APP);

module.exports = AppFlowController;