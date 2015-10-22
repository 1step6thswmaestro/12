var CodedWeather = require('../constants/CodedWeather');
var LanguageSelector = require('./LanguageSelector');

var icons = {};
var formats = ['CloudCodes', 'CoverageCodes', 'IntensityCodes', 'WeatherCodes'];

var WeatherCodeUtil = {
    getForecastText: function(_primaryCode) {
        if (_primaryCode == null || _primaryCode == undefined) { return null; }

        var forecastText = "";

        if (_primaryCode.indexOf(0) == ':') {
            var code = _primaryCode.slice(2,4);
            forecastText += this._getTextFromCode(code, formats[0]);
        }
        else {
            var codes = _primaryCode.split(":");
            if (codes.length < 3 || codes == undefined || codes == null) { throw new Error("Error: Invalid Primary Code"); }

            for(var idx=0; idx<3; idx++) {
                var code = codes[idx];
               forecastText += this._getTextFromCode(code, formats[idx]);
            }
        }

        return forecastText;
    },

    _getTextFromCode: function(code, format) {
        if (this.__checkProperty(CodedWeather[format], code)) {
            if (this.__checkProperty(CodedWeather[format][code], LanguageSelector.getCurrentLanguage())) {
                return CodedWeather[format][code][LanguageSelector.getCurrentLanguage()];
            }
        }
    },

    __checkProperty: function(obj, property) {
        if (!obj.hasOwnProperty(property)) {
            throw new Error("Error: Invalid Property", property);
        }
        return true;
    }
};

module.exports = WeatherCodeUtil;