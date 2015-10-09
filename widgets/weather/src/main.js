"use strict";


require('events').EventEmitter.prototype._maxListeners = 100;

var d3 = require('d3');

var API = require('./apis/API');
var WeatherStore = require('./stores/WeatherStore');

var TodayWeather = require('./components/TodayWeather/TodayWeather');

var WeatherIcons = require('./utils/WeatherIcons');
var Observer = require('./utils/Observer');

var IndexLoadObserver;
var APIDataReceiveAlimi = 'APIDataReceiveAlimi';


$(document).ready(function() {
    IndexLoadObserver = new Observer(WeatherIcons.initialize, APIDataReceiveAlimi);
    IndexLoadObserver.addCompleteListener(LoadComplete);

    WeatherStore.addReceiveDataListener(DataLoaded);
    API.getForecastData();

    WeatherIcons.initialize($, IndexLoadObserver);
    TodayWeather.initialize($);
});


var DataLoaded = function() {
    IndexLoadObserver.done(APIDataReceiveAlimi);
    //WeatherList.flip();

    $('#day-select-slider').slick({
        infinite: false,
        slidesToShow: 5,
        slidesToScroll: 3,
        arrows: false
    });
};

var LoadComplete = function() {
    $('#loader').animate({
        opacity: 0
    }, '600', 'easeInCubic', function() {
        $('#loader').remove();
    });

    $('#app').removeAttr('style');

    $('#app').animate({
        opacity: 1
    }, '1200', 'easeInCubic');

    IndexLoadObserver.removeCompleteListener(LoadComplete);
};
