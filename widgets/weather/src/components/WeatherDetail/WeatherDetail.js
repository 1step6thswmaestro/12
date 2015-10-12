var DateSelector = require('./DateSelector');
var MainDetail = require('./MainDetail');
var TempGraph = require('./TempGraph');

var WeatherDetail = {
    initialize: function($) {
        DateSelector.initialize($);
        MainDetail.initialize($);
        TempGraph.initialize($);
    }
};

module.exports = WeatherDetail;