var FlowController = require('../../../../lib/Flowing');
var Constants = require('../constants/Constants');

var AppFlowController = new FlowController();

for (var prop in Constants.TodoFlowID) {
    AppFlowController.addFlow({ID: Constants.TodoFlowID[prop]});
}

module.exports = AppFlowController;