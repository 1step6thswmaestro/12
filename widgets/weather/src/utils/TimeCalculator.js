var Observer = require('./Observer');


var currentDate;

var TimeCalculator = {
    valueUpdateTime: [0, 3, 6, 9, 12, 15, 18, 21],

    calcForecastLimit: function() {
        currentDate = new Date();
    }
};

module.exports = TimeCalculator;