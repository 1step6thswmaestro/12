var APIActionCreator = require('../actions/APIActionCreator');
var Constants = require('../constants/Constants');
var request = require('superagent');

console.log(APIActionCreator);

var API = {
    getForecastData: function() {
        request
            .get(Constants.API.GET_FORECAST_DATA + "/" + Constants.CountryCode.Seoul)
            .query({client_id: Constants.API.CLIENT_ID, client_secret: Constants.API.CLIENT_SECRET, limit: 111, filter: '3hr'})
            .end(function(err,res) {
                if (err) { console.log(err); }
                else {
                    APIActionCreator.receiveForecastData(res.body.response[0]);
                }
            });
    }
};

module.exports = API;