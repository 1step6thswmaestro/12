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

        this['sun-rise'] = TimeLine.find('[weather-attr=sun-rise]');
        this['sun-set'] = TimeLine.find('[weather-attr=sun-set]');

        this['twilight-start'] = TimeLine.find('[weather-attr=twilight-start]');
        this['twilight-end'] = TimeLine.find('[weather-attr=twilight-end]');

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
            //var options = {
            //    useEasing : true,
            //    useGrouping : true,
            //    separator : ',',
            //    decimal : '.',
            //    prefix : this.__convertLeadingZeros(newTextDate.getHours(), 2) + ":",
            //    suffix : ''
            //};

            if (prop == 'sun-rise') { sunRiseTime = newTextDate; }
            if (prop == 'sun-set') { sunSetTime = newTextDate; }

            //var countText = new CountUp(prop, texts[prop]*=1, newTextDate.getMinutes(), 0, 2.5, options);
            //countText.start();

            var text = this.__convertLeadingZeros(newTextDate.getHours(), 2) + ":" + this.__convertLeadingZeros(newTextDate.getMinutes(), 2);
            this[prop].text(text);
        }


        var length = (sunSetTime.getHours() - sunRiseTime.getHours()) * 60 * 60 + (sunSetTime.getMinutes() - sunRiseTime.getMinutes()) * 60;
        var flexGrowth = 6 * length / STANDARD_DAY_LENGTH;

        this.dayLength.css('flex-grow', flexGrowth);
    },


    __convertLeadingZeros: function(number, digits) {
        var zero = '';
        number = number.toString();

        if (number.length < digits) {
            for (var i = 0; i < digits - number.length; i++)
                zero += '0';
        }
        return zero + number;
    }
};

module.exports = SunAndMoon;