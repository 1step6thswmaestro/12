"use strict";

var TodayWeather = require('./components/TodayWeather/TodayWeather');
var WeatherDetail = require('./components/WeatherDetail/MainDetail');
var WeatherIcons = require('./utils/WeatherIcons');
var Loader = require('./components/Loader/Loader');

$(document).ready(function() {
    WeatherIcons.initialize($);
    TodayWeather.initialize($);
    WeatherDetail.initialize($);

    Loader.initialize($);
    Loader.loadStart();
});
