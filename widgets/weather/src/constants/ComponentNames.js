var keyMirror = require('react/lib/keyMirror');

module.exports = {
    Loader: {
        ID: 'loader'
    },

    TodayWeather: {
        ID: 'today-weather-component',
        ATTRIBUTES: {
            'today-weather-icon': null,
            'today-weather-highTemp': 'maxTempC',
            'today-weather-lowTemp': 'minTempC',
            'today-weather-description': null
        }
    },

    DayWeatherHeader: {
        ID: 'day-weather-header',
        ATTRIBUTES: {
            'detail-icon': null,
            'detail-description': null,
            'detail-highTemp': 'maxTempC',
            'detail-lowTemp': 'minTempC'
        }
    },

    DayWeatherDetail: {
        ID: 'day-weather-detail',
        ATTRIBUTES: {
            'detail-feel-like': 'feelslikeC',
            'humanity': 'humidity',
            'dew-point': 'dewpointC',
            'precipitation': 'pop',
            'precipMM': 'precipMM',
            'snowCM': 'snowCM'
        }
    },

    SunAndMoon: {
        ID: 'day-weather-sun-and-moon',
        ATTRIBUTES: {
            'twilight-start': null,
            'sun-rise': "rise",
            'sun-set': "set",
            'twilight-end': null,

            'day-length': null
        }
    },

    WindAndPressure: {
        ID: 'day-weather-wind-and-pressure',
        ATTRIBUTES: {
            'anemometer': null,
            'barometer': null
        }
    },

    TempGraph: {
        ID: 'detail-tempGraph'
    },

    DateSelector: {
        ID: 'detail-date-selector',
        SUB_COMPONENTS: {
            LEFT_BUTTON: {
                ID: 'arrow-left'
            },
            RIGHT_BUTTON: {
                ID: 'arrow-right'
            },
            SLIDER: {
                ID: 'day-select-slider'
            },
            DAY_ITEM: {
                ID: 'day-item-PROTO',
                ATTRIBUTES: {
                    'day-of-week': null,
                    'date': null,
                    'icon': null,
                    'high-temp': null,
                    'low-temp': null
                }
            }
        }
    }
};