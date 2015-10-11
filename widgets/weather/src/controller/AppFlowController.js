var FlowController = require('flow-controller').FlowController;
var Constants = require('../constants/Constants');

var AppFlowController = new FlowController();

AppFlowController.addFlow({ID: Constants.FlowID.GET_FORECAST_DATA});
AppFlowController.addFlow({ID: Constants.FlowID.GET_SUN_MOON_DATA});

module.exports = AppFlowController;