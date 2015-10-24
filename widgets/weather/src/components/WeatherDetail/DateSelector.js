var AppFlowController = require('../../controller/AppFlowController');
var WeatherStore = require('../../stores/WeatherStore');
var Constants = require('../../constants/Constants');

var EventEmitter = require('events').EventEmitter;
var _ = require('underscore');

var _DayItemView = require('./_DayItemView');

var DateSelectorDOM;
var SelectorItemDOMs;
var ArrowLeftDOM;
var ArrowRightDOM;
var ItemProtoDOM;

var ItemDatas = [];
var currentIndex;


var DateSelector = _.extend({}, EventEmitter.prototype, {
    initialize: function($) {
        DateSelectorDOM = $('#day-select-slider');
        SelectorItemDOMs = $('.day-select-slider-item');

        ArrowLeftDOM = $('#arrow-left');
        ArrowRightDOM = $('#arrow-right');

        this.initSlider($);
    },

    initSlider: function($) {
        DateSelectorDOM.slick({
            infinite: false,
            slidesToShow: 5,
            slidesToScroll: 3,
            arrows: false,
            dots: false
        });
        //DateSelectorDOM.slick('setPosition');

        currentIndex = 0;

        ArrowLeftDOM.on('click tap', function() { DateSelectorDOM.slick('slickPrev'); });
        ArrowRightDOM.on('click tap', function() { DateSelectorDOM.slick('slickNext'); });


        var _this = this;
        SelectorItemDOMs.on('click tap', function() {
            currentIndex = $(this).attr('idx');
            console.log("currentIndex", currentIndex);
            SelectorItemDOMs.removeClass('active');
            $(this).addClass('active');
            _this.emitSlideChange();
        });

        _this.emitSlideChange();
    },

    initItems: function() {
        ItemDatas = (WeatherStore.getTwoWeeksData()).periods;

        for (var idx= 0, len=ItemDatas.length; idx<len; idx++) {
            var ItemView = new _DayItemView(DateSelectorDOM.children().find('[idx=' + idx +']'));
            ItemView.initialize(ItemDatas[idx]);
        }
    },

    subscribeActiveApp: AppFlowController.addSubscribe(
        Constants.FlowID.ACTIVE_APP,
        function() {
            DateSelectorDOM.slick('slickGoTo', 0);
        }
    ),

    getCurrentIndex: function() {
        return currentIndex;
    },

    emitSlideChange: function() { this.emit('slideChange'); },
    addSlideChangeListener: function(callback) { this.on('slideChange', callback); },
    removeSlideChangeListener: function(callback) { this.removeListener('slideChange', callback); }
});

module.exports = DateSelector;