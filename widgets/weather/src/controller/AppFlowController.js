var FlowController = require('flowing-js').FlowController;
var Constants = require('../constants/Constants');

var AppFlowController = new FlowController();

AppFlowController.addFlow(Constants.FlowID.GET_FORECAST_DATA);
AppFlowController.addFlow(Constants.FlowID.GET_SUN_MOON_DATA);

module.exports = AppFlowController;