var FlowController = require('flowing-js').FlowController;
var Constants = require('../constants/Constants');

var AppFlowController = new FlowController();

AppFlowController.addFlow(Constants.FlowID.LOAD_PICTURES);


module.exports = AppFlowController;