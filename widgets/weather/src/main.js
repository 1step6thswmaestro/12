"use strict";
var Loader = require('./components/Loader/Loader');
var TodayWeather = require('./components/TodayWeather/TodayWeather');
var WeatherDetail = require('./components/WeatherDetail/WeatherDetail');

var WeatherIcons = require('./utils/WeatherIcons');
var TimeCalculator = require('./utils/TimeCalculator');


$(document).ready(function() {
    WeatherIcons.initialize($);

    Loader.initialize($);

    TodayWeather.initialize($);
    WeatherDetail.initialize($);

    TimeCalculator.initialize();
});