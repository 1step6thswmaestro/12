var DateSelectorDOM;

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
    }
};

module.exports = DateSelector;