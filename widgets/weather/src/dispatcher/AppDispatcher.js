var AppFlowController = require('../controller/AppFlowController');
var Constants = require('../constants/Constants');

var AppDispatcher = {
    getForecastData: function(dataAmount) {
        AppFlowController.dispatch(
            Constants.FlowID.GET_FORECAST_DATA,
            { dataAmount: dataAmount }
        );
    },

    getSunMoonData: function() {
        AppFlowController.dispatch(
            Constants.FlowID.GET_SUN_MOON_DATA,
            {}
        );
    }
};

module.exports = AppDispatcher;