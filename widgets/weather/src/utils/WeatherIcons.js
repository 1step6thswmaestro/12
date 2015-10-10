var CodedWeather = require('../constants/CodedWeather');

var Icons = {};

var WeatherIcons = {
    initialize: function($, observer) {
        for (var prop in CodedWeather.Icons) {
            this.loadDOM($, CodedWeather.Icons[prop]);
            this.loadDOM($, CodedWeather.Icons[prop]);
        }
        observer.done(this.initialize);
        $('#weather-animated-icons').remove();
        console.log("Icons", Icons);
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