var keyMirror = require('react/lib/keyMirror');

var APIroot = 'http://api.aerisapi.com';

module.exports = {
    API: {
        CLIENT_ID: 'fJIotEHpBOU2rRNKtW4tw',
        CLIENT_SECRET: 'NwT2TnHj3WLh8JcfJOKpLXiwoLjcPRV5A2988uBb',
        GET_FORECAST_DATA: APIroot + '/forecasts',
        GET_SUN_MOON_DATA: APIroot + '/sunmoon'
    },

    FlowID: keyMirror({
        GET_FORECAST_DATA: null,
        GET_14_FORECAST_DATA: null,
        GET_SUN_MOON_DATA: null,

        ACTIVE_APP: null,
        DISABLE_APP: null
    }),

    CountryCode: {
        Seoul: 'seoul,kr'
    },

    KeyCode: {
        ENTER: 13,
        TAB: 9,
        ARROW_DOWN: 40,
        ARROW_UP: 38,
        BACKSPACE: 8
    }
};