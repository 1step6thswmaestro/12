var CodedWeather = require('../constants/CodedWeather');

var $;
var Icons = {};

function loadDOM($, id) {
    if (Icons.hasOwnProperty(id)) { return; }

    var _dom = $('#' + id).clone();
    $('#' + id).remove();
    _dom.removeAttr('id');

    Icons[id] = { DOM: _dom };
}

/**
 * 이 클래스는 날씨 아이콘(SVG 포맷) DOM 관련 유틸리티입니다.
 *
 * inititalize(): 이 클래스를 초기화하고 날씨 아이콘 DOM들을 Icons에 저장합니다.
 * getIconDOM(@id): @id에 해당하는 날씨 아이콘 DOM을 반환합니다.
 *
 * @version 151028
 * @author 나석주
 */
var WeatherIcons = {
    initialize: function(_$) {
        $ = _$;
        for (var prop in CodedWeather.Icons) {
            loadDOM($, CodedWeather.Icons[prop]);
        }
        $('#weather-animated-icons').remove();
    },

    getIconDOM: function(id) {
        if (!Icons.hasOwnProperty(id)) { throw new Error("해당 id의 날씨 정보가 없습니다."); }
        return Icons[id].DOM;
    }
};


module.exports = WeatherIcons;