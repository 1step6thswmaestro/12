"use strict";

var TodayWeather = require('./components/TodayWeather/TodayWeather');
var WeatherIcons = require('./utils/WeatherIcons');
var Loader = require('./components/Loader/Loader');

$(document).ready(function() {
    WeatherIcons.initialize($);
    TodayWeather.initialize($);

    Loader.initialize($);
    Loader.loadStart();
});
