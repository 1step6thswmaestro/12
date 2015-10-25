var LanguageSelector = require('../../../utils/LanguageSelector');
var Loacalize = require('../../../constants/Localize');

var DateSelector = require('../DateSelector');
var WeatherStore = require('../../../stores/WeatherStore');


var DOM;
var texts = {
    'anemometer': 0,
    'barometer': 0
};

var WindAndPressure = {
    initialize: function($) {
        DOM = $('#day-weather-wind-and-pressure');

        this.descriptionDOMs = {
            'anemometer': DOM.find('[text-attr=anemometer]'),
            'barometer': DOM.find('[text-attr=barometer]')
        };

        this.windFan = DOM.find('[weather-attr=wind-fan]');

        this.initDescriptionText(LanguageSelector.getCurrentLanguage());
        DateSelector.addSlideChangeListener(this.displayContext.bind(this));
    },

    initDescriptionText: function(lang) {
        for (var prop in this.descriptionDOMs) {
            this.descriptionDOMs[prop].text(Loacalize.WindAndPressure[prop][lang]);
        }
    },

    displayContext: function() {
        var index = DateSelector.getCurrentIndex();
        var data = (WeatherStore.getTwoWeeksData()).periods[index];

        var optionsForAnemometer = {
            useEasing : true,
            useGrouping : true,
            separator : ',',
            decimal : '.',
            prefix : '',
            suffix : " km/h " + data['windDir']
        };
        var optionsForBarometer = {
            useEasing : true,
            useGrouping : true,
            separator : ',',
            decimal : '.',
            prefix : '',
            suffix : " mBar"
        };

        var countForAnemometer = new CountUp('anemometer', texts['anemometer']*=1, data['windSpeedKPH']*=1, 0, 2.5, optionsForAnemometer);
        var countForBarometer = new CountUp('barometer', texts['barometer']*=1, data['pressureMB']*=1, 0, 2.5, optionsForBarometer);

        texts['anemometer'] = data['windSpeedKPH'];
        texts['barometer'] = data['pressureMB'];

        countForAnemometer.start();
        countForBarometer.start();
    }
};

module.exports = WindAndPressure;