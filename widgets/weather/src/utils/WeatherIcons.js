var CodedWeather = require('../constants/CodedWeather');

var $;
var Icons = {};

var WeatherIcons = {
    initialize: function(_$) {
        $ = _$;
        for (var prop in CodedWeather.Icons) {
            this.loadDOM($, CodedWeather.Icons[prop]);
        }
        $('#weather-animated-icons').remove();
    },

    loadDOM: function($, id) {
        if (Icons.hasOwnProperty(id)) { return; }

        var _dom = $('#' + id).clone();
        $('#' + id).remove();
        _dom.removeAttr('id');

        Icons[id] = { DOM: _dom };
    },

    getIconDOM: function(id) {
        if (!Icons.hasOwnProperty(id)) { throw new Error("해당 id의 날씨 정보가 없습니다."); }
        return Icons[id].DOM;
    }
};


module.exports = WeatherIcons;