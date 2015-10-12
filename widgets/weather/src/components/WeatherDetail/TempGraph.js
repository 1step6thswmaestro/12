var TempGraphDOM;
var WrapperDOM;

var TempGraph = {
    initialize: function($) {
        TempGraphDOM = $("#detail-tempGraph");
        WrapperDOM = $('#tempGraph-wrapper');


        google.setOnLoadCallback(drawChart());

        function drawChart() {
            /*
            var data = google.visualization.arrayToDataTable([
                ['Year', 'Sales', 'Expenses'],
                ['2013', 1000, 400],
                ['2014', 1170, 460],
                ['2015', 660, 1120],
                ['2016', 1030, 540]
            ]);
            */

            var data = new google.visualization.arrayToDataTable([
                ['Time', 'hhhh', 'hhoho'],
                ['00', 23, 12],
                ['03', 24, 15],
                ['06', 25, 16],
                ['09', 26, 13],
                ['12', 25, 15],
                ['15', 23, 11],
                ['18', 22, 13],
                ['21', 24, 11],
                ['24', 20, 12]
            ]);



            var height = WrapperDOM.actual('height');
            var width = $(window).width();

            var options = {
                width: width,
                height: height,
                annotationText: true,
                chartArea: {width: '100%', height: '80%'},
                hAxis: {
                    textStyle: {color: 'white'}
                },
                vAxis: {baselineColor: 'black', gridlines: {color: 'black'}},
                backgroundColor: 'black'
            };

            var chart = new google.visualization.AreaChart(document.getElementById('detail-tempGraph'));
            chart.draw(data, options);
        }
    }
};

module.exports = TempGraph;