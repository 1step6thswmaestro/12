var DateSelector = require('./DateSelector');
var TempGraph = require('./TempGraph');


var WeatherDetail = {
    initialize: function($) {
        DateSelector.initialize($);
        TempGraph.initialize($);
    }
};

module.exports = WeatherDetail;