var LanguageSelector = require('../../../utils/LanguageSelector');
var Loacalize = require('../../../constants/Localize');

var DateSelector = require('../DateSelector');
var WeatherStore = require('../../../stores/WeatherStore');

var DOM;
var texts = {
    'feelLike': 0,
    'humanity': 0,
    'dewPoint': 0,
    'precipitation': 0,
    'precipMM': 0,
    'snowCM': 0
};
var options = {
    useEasing : true,
    useGrouping : true,
    separator : ',',
    decimal : '.',
    prefix : '',
    suffix : ''
};

var DayWeatherDetail = {
    initialize: function($) {
        DOM = $('#day-weather-detail');

        this.descriptionDOMs = {
            'feel-like': DOM.find('[text-attr=feel-like]'),
            'humanity': DOM.find('[text-attr=humanity]'),
            'dew-point': DOM.find('[text-attr=dew-point]'),
            'precipitation': DOM.find('[text-attr=precipitation]'),
            'precipMM': DOM.find('[text-attr=precipMM]'),
            'snowCM': DOM.find('[text-attr=snowCM]')
        };

        this.feelLike = DOM.find('[weather-attr=feel-like]');
        this.humanity = DOM.find('[weather-attr=humanity]');
        this.dewPoint = DOM.find('[weather-attr=dew-point]');
        this.precipitation = DOM.find('[weather-attr=precipitation]');
        this.precipMM = DOM.find('[weather-attr=precipMM]');
        this.snowCM = DOM.find('[weather-attr=snowCM]');


        this.initDescriptionText(LanguageSelector.getCurrentLanguage());
        DateSelector.addSlideChangeListener(this.displayContext.bind(this));
    },

    initDescriptionText: function(lang) {
        for (var prop in this.descriptionDOMs) {
            this.descriptionDOMs[prop].text(Loacalize.DayWeatherDetail[prop][lang]);
        }
    },

    displayContext: function() {
        var index = DateSelector.getCurrentIndex();

        var data = (WeatherStore.getTwoWeeksData()).periods[index];

        for (var prop in texts) {
            var decimal = (prop == 'precipMM' || prop == 'snowCM') ? 2 : 0;
            var newTextData = (function() {
                switch(prop) {
                    case 'feelLike': return data['feelslikeC'];
                    case 'humanity': return data['humidity'];
                    case 'dewPoint': return data['dewpointC'];
                    case 'precipitation': return data['pop'];
                    case 'precipMM': return data['precipMM'];
                    case 'snowCM': return data['snowCM'];
                }
            })();

            if (prop == 'precipMM' || prop == 'snowCM') {
                if (newTextData == 0) {
                    this[prop].text("--");
                    continue;
                }
            }

            var countText = new CountUp(prop, texts[prop]*=1, newTextData*=1, decimal, 2.5, options);
            countText.start();

            texts[prop] = newTextData;
        }
    }
};


module.exports = DayWeatherDetail;