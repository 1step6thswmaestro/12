var Localize = require('../../constants/Localize');
var LanguageSelector = require('../../utils/LanguageSelector');
var CodedWeather = require('../../constants/CodedWeather');
var WeatherIcons = require('../../utils/WeatherIcons');
var _ = require('underscore');


function _calcDayOfWeek(day) {
    var days = [
        {EN: 'SUN', KR: '일요일'},
        {EN: 'MON', KR: '월요일'},
        {EN: 'TUE', KR: '화요일'},
        {EN: 'WED', KR: '수요일'},
        {EN: 'THU', KR: '목요일'},
        {EN: 'FRI', KR: '금요일'},
        {EN: 'SAT', KR: '토요일'}
    ];

    switch(day) {
        case -2: return Localize.DateSelector['today'][LanguageSelector.getCurrentLanguage()];
        case -1: return Localize.DateSelector['tomorrow'][LanguageSelector.getCurrentLanguage()];
        default: return days[day][LanguageSelector.getCurrentLanguage()];
    }
}

var _DayItemView = (function() {
    function _DayItemView(_DOM) {
        this.DOM = _DOM;

        this.day = _DOM.find('[item-attr=day-of-week]');
        this.date = _DOM.find('[item-attr=date]');
        this.icon = _DOM.find('[item-attr=icon]');
        this.highTemp = _DOM.find('[item-attr=high-temp]');
        this.lowTemp = _DOM.find('[item-attr=low-temp]');
    }

    _DayItemView.prototype.initialize = function(datas) {
        var thisDate = new Date(datas['dateTimeISO']);

        var today = new Date();
        var tomorrow = new Date(today.valueOf() + (24*60*60*1000));

        var dayOfWeek;

        if ((thisDate.getDate() == today.getDate()) && (thisDate.getMonth() == today.getMonth())) {
            dayOfWeek = _calcDayOfWeek(-2);
        }
        else if ((thisDate.getDate() == tomorrow.getDate()) && (thisDate.getMonth() == tomorrow.getMonth())) {
            dayOfWeek = _calcDayOfWeek(-1);
        }
        else {
            dayOfWeek = _calcDayOfWeek(thisDate.getDay());
        }

        this.day.text(dayOfWeek);
        this.date.text((thisDate.getMonth() + 1) + "." + thisDate.getDate());

        this.icon.empty();
        var iconDOM = WeatherIcons.getStaticIconDOM(datas['icon']).clone();
        this.icon.append(iconDOM);

        this.highTemp.text(datas['maxTempC']);
        this.lowTemp.text(datas['minTempC']);
    };

    return _DayItemView;
})();


module.exports = _DayItemView;