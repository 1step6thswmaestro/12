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

var ItemDatas = [];
var currentIndex;

var $;

/**
 * 이 클래스는 DateSelector 컴포넌트입니다.
 *
 * initialize(): 이 클래스를 초기화합니다. DOM 객체를 저장합니다.
 * initSlider(): 컴포넌트의 슬라이더를 초기화합니다.
 * initItems(): 컴포넌트의 슬라이더에 아이템들을 초기화합니다.
 * selectItem(): 슬라이더의 아이템이 선택되었을때 실행되는 콜백 메소드입니다.
 * getCurrentIndex(): 현재 선택된 아이템의 index를 반환합니다.
 *
 * @version 151108
 * @author 나석주
 */
var DateSelector = _.extend({}, EventEmitter.prototype, {
    initialize: function(_$) {
        $ = _$;

        DateSelectorDOM = $('#day-select-slider');
        SelectorItemDOMs = $('.day-select-slider-item');

        ArrowLeftDOM = $('#arrow-left');
        ArrowRightDOM = $('#arrow-right');
    },

    initSlider: function() {
        DateSelectorDOM.owlCarousel({
            items: 5,
            itemsDesktop: [1199,5],
            itemsDesktopSmall: [979,5],
            itemsTablet: [768,5]
        });
        DateSelectorDOM.attr('style', 'display: flex');

        currentIndex = 0;

        ArrowLeftDOM.on('click tap', function() { DateSelectorDOM.trigger('owl.prev'); });
        ArrowRightDOM.on('click tap', function() { DateSelectorDOM.trigger('owl.next'); });

        var that = this;
        SelectorItemDOMs.on('click tap', function() {
            that.selectItem(this, that);
        });

        this.initItems();
    },

    initItems: function() {
        ItemDatas = (WeatherStore.getTwoWeeksData()).periods;

        for (var idx= 0, len=ItemDatas.length; idx<len; idx++) {
            var ItemView = new _DayItemView(DateSelectorDOM.children().find('[idx=' + idx +']'));
            ItemView.initialize(ItemDatas[idx]);
        }

        this.selectItem(SelectorItemDOMs.eq(0), this);
        this.refresh();
    },

    refresh: function() {
    },

    selectItem: function(selectedItemDOM, _this) {
        currentIndex = $(selectedItemDOM).attr('idx');

        SelectorItemDOMs.removeClass('active');
        $(selectedItemDOM).addClass('active');

        _this.emitSlideChange();
    },

    getCurrentIndex: function() {
        return currentIndex;
    },

    isFirstIsTomorrow: function() {
        var today = new Date();
        var dataDay = new Date(ItemDatas[0]['dateTimeISO']);

        return ((today.getMonth() == dataDay.getMonth()) && (today.getDate() == dataDay.getDate()));
    },

    emitSlideChange: function() { this.emit('slideChange'); },
    addSlideChangeListener: function(callback) { this.on('slideChange', callback); },
    removeSlideChangeListener: function(callback) { this.removeListener('slideChange', callback); }
});

module.exports = DateSelector;
