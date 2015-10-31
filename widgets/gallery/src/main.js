'use strict';

$(document).ready(function() {

    $('#dsff').slick({
        dots: false,
        arrows: false,
        infinite: false,
        slidesToShow: 5,
        slidesToScroll: 2,
        adaptiveHeight: true
    });
    $('#dsff').slick('slickGoTo', 0);
});