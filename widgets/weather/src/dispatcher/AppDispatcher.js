var AppFlowController = require('../controller/AppFlowController');
var Constants = require('../constants/Constants');

var AppDispatcher = {
    getForecastData: function(dataAmount) {
        AppFlowController.dispatch(
            Constants.FlowID.GET_FORECAST_DATA,
            { dataAmount: dataAmount }
        );
    },

    getTwoWeeksData: function() {
        AppFlowController.dispatch(
            Constants.FlowID.GET_14_FORECAST_DATA,
            {}
        );
    },

    getSunMoonData: function() {
        AppFlowController.dispatch(
            Constants.FlowID.GET_SUN_MOON_DATA,
            {}
        );
    },

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