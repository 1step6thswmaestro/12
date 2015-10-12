var TempGraph = require('./TempGraph');
var DateSelector = require('./DateSelector');

var MainDetail = {
    initialize: function($) {
        DateSelector.initialize($);
        TempGraph.initialize($);
    }
};

module.exports = MainDetail;