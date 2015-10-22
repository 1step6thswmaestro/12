var FlowController = require('flowing-js').FlowController;
var Constants = require('../constants/Constants');

var AppFlowController = new FlowController();

AppFlowController.addFlow(Constants.FlowID.GET_FORECAST_DATA);
AppFlowController.addFlow(Constants.FlowID.GET_SUN_MOON_DATA);

AppFlowController.addFlow(Constants.FlowID.ACTIVE_APP);
AppFlowController.addFlow(Constants.FlowID.DISABLE_APP);

module.exports = AppFlowController;