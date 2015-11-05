"use strict";
var Loader = require('./components/Loader/Loader');
var TodayWeather = require('./components/TodayWeather/TodayWeather');
var WeatherDetail = require('./components/WeatherDetail/WeatherDetail');

var WeatherIcons = require('./utils/WeatherIcons');
var TimeCalculator = require('./utils/TimeCalculator');



/**
 * 이 클래스는 컴포넌트 모듈을 초기화하기 위한 클래스입니다.
 * 이 클래스는 DOM 트리 구축이 완료 되었을 때 호출됩니다.
 *
 * @version 151028
 * @author 나석주
 */
$(document).ready(function() {
    WeatherIcons.initialize($);

    Loader.initialize($);

    TodayWeather.initialize($);
    WeatherDetail.initialize($);

    TimeCalculator.initialize();
});