var WeatherConditionConstants = require('../constants/WeatherConditionConstants');

var Icons = {};

var AnimatedIcons = {
    initialize: function($, observer) {
        for (var prop in WeatherConditionConstants) {
            this.loadDOM($, WeatherConditionConstants[prop]['day-id']);
            this.loadDOM($, WeatherConditionConstants[prop]['night-id']);
        }
        observer.done(this.initialize);
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
        console.log("id", id);
        if (!Icons.hasOwnProperty(id)) { throw new Error("해당 id의 날씨 정보가 없습니다."); }
        return Icons[id].DOM;
    }
};


module.exports = AnimatedIcons;