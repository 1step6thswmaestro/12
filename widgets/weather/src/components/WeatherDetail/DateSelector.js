var DateSelectorDOM;

var ArrowLeftDOM;
var ArrowRightDOM;

var DateSelector = {
    initialize: function($) {
        DateSelectorDOM = $('.day-select-slider');
        DateSelectorDOM.slick({
            infinite: false,
            slidesToShow: 5,
            slidesToScroll: 3,
            arrows: false,
            dots: false
        });
        DateSelectorDOM.slick('slickGoTo', 0);

        ArrowLeftDOM = $('#arrow-left');
        ArrowRightDOM = $('#arrow-right');

        ArrowLeftDOM.on('click tap', function() { DateSelectorDOM.slick('slickPrev'); });
        ArrowRightDOM.on('click tap', function() { DateSelectorDOM.slick('slickNext'); });
    }
};

module.exports = DateSelector;