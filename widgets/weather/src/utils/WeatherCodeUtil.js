var CodedWeather = require('../constants/CodedWeather');
var LanguageSelector = require('./LanguageSelector');

var icons = {};
var formats = ['CloudCodes', 'CoverageCodes', 'IntensityCodes', 'WeatherCodes'];


/**
 * 이 클래스는 날씨 API의 primaryCode를 String으로 변환하기 위한 클래스입니다.
 *
 * getForecastText(@primaryCode): @primaryCode를 의미있는 String으로 변환합니다.
 *
 * @version 151028
 * @author 나석주
 */
var WeatherCodeUtil = {
    getForecastText: function(_primaryCode) {
        if (_primaryCode == null || _primaryCode == undefined) { return null; }

        var forecastText = "";
        var code;

        if (_primaryCode.charAt(0) == ':' && _primaryCode.charAt(1) == ':') {
            code = _primaryCode.slice(2,4);
            forecastText += this._getTextFromCode(code, formats[0]);
        }
        else {
            var codes = _primaryCode.split(":");
            if (codes.length < 3 || codes == undefined || codes == null) { throw new Error("Error: Invalid Primary Code"); }

            for(var idx=0; idx<3; idx++) {
                code = codes[idx];
                forecastText += (this._getTextFromCode(code, formats[idx+1]) + " ");
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
        return "";
    },

    __checkProperty: function(obj, property) {
        if (!obj.hasOwnProperty(property)) {
            return false;
        }
        return true;
    }
};

module.exports = WeatherCodeUtil;