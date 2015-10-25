var LanguageSelector = require('../../../utils/LanguageSelector');
var Loacalize = require('../../../constants/Localize');

var DateSelector = require('../DateSelector');
var WeatherStore = require('../../../stores/WeatherStore');


var DOM;
var TimeLine;
var texts = {
    'sun-rise': 0,
    'sun-set': 0,
    'twilight-start': 0,
    'twilight-end': 0
};
var STANDARD_DAY_LENGTH = 12 * 60 * 60; //초 단위


var SunAndMoon = {
    initialize: function($) {
        DOM = $('#day-weather-sun-and-moon');
        TimeLine = DOM.find('#time-line');

        this.descriptionDOMs = {
            'helper-day': DOM.find('[text-attr=helper-day]'),
            'helper-twilight': DOM.find('[text-attr=helper-twilight]'),
            'helper-night': DOM.find('[text-attr=helper-night]')
        };

        this.sunRise = TimeLine.find('[weather-attr=sun-rise]');
        this.sunSet = TimeLine.find('[weather-attr=sun-set]');

        this.twilightStart = TimeLine.find('[weather-attr=twilight-start]');
        this.twilightEnd = TimeLine.find('[weather-attr=twilight-end]');

        this.dayLength = TimeLine.find('[weather-attr=day-length]');


        this.initDescriptionText(LanguageSelector.getCurrentLanguage());
        DateSelector.addSlideChangeListener(this.displayContext.bind(this));
    },

    initDescriptionText: function(lang) {
        for (var prop in this.descriptionDOMs) {
            this.descriptionDOMs[prop].text(Loacalize.SunAdnMoon[prop][lang]);
        }
    },

    displayContext: function() {
        var index = DateSelector.getCurrentIndex();

        if (index == 0) { this._contextForToday(index); }
        else { this._contextForOtherDays(index); }
    },

    _contextForToday: function() {

    },

    _contextForOtherDays: function(index) {
        var data = (WeatherStore.getSunMoonData())[index].sun;

        var sunRiseTime;
        var sunSetTime;

        for (var prop in texts) {
            var newTextDate = (function() {
                switch(prop) {
                    case 'sun-rise': return new Date(data['riseISO']);
                    case 'sun-set': return new Date(data['setISO']);
                    case 'twilight-start': return new Date(data.twilight['civilBeginISO']);
                    case 'twilight-end': return new Date(data.twilight['civilEndISO']);
                }
            })();
            var options = {
                useEasing : true,
                useGrouping : true,
                separator : ',',
                decimal : '.',
                prefix : this.__convertHourToString(newTextDate.getHours()) + ":",
                suffix : ''
            };

            if (prop == 'sun-rise') { sunRiseTime = newTextDate; }
            if (prop == 'sun-set') { sunSetTime = newTextDate; }

            var countText = new CountUp(prop, texts[prop]*=1, newTextDate.getMinutes(), 0, 2.5, options);
            countText.start();

            texts[prop] = newTextDate.getMinutes();
        }

        var length = (sunSetTime.getHours() - sunRiseTime.getHours()) * 60 * 60 + (sunSetTime.getMinutes() - sunRiseTime.getMinutes()) * 60;
        var flexGrowth = 6 * length / STANDARD_DAY_LENGTH;

        this.dayLength.css('flex-grow', flexGrowth);
    },


    __convertHourToString: function(hour) {
        switch(hour) {
            case 0: return "00";
            case 1: return "01";
            case 2: return "02";
            case 3: return "03";
            case 4: return "04";
            case 5: return "05";
            case 6: return "06";
            case 7: return "07";
            case 8: return "08";
            case 9: return "09";
            case 10: return "10";
            case 11: return "11";
            case 12: return "12";
            case 13: return "13";
            case 14: return "14";
            case 15: return "15";
            case 16: return "16";
            case 17: return "17";
            case 18: return "18";
            case 19: return "19";
            case 20: return "20";
            case 21: return "21";
            case 22: return "22";
            case 23: return "23";
        }
    }
};

module.exports = SunAndMoon;