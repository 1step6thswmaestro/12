var AppFlowController = require('../../controller/AppFlowController');
var WeatherStore = require('../../stores/WeatherStore');
var Constants = require('../../constants/Constants');

var _DayItemView = require('./_DayItemView');

var DateSelectorDOM;
var ArrowLeftDOM;
var ArrowRightDOM;
var ItemProtoDOM;

var ItemDatas = [];
var currentIndex;


var DateSelector = {
    initialize: function($) {
        DateSelectorDOM = $('#day-select-slider');

        ArrowLeftDOM = $('#arrow-left');
        ArrowRightDOM = $('#arrow-right');

        DateSelectorDOM.slick({
            infinite: false,
            slidesToShow: 5,
            slidesToScroll: 3,
            arrows: false,
            dots: false
        });
        DateSelectorDOM.slick('slickGoTo', 0);

        ArrowLeftDOM.on('click tap', function() { DateSelectorDOM.slick('slickPrev'); });
        ArrowRightDOM.on('click tap', function() { DateSelectorDOM.slick('slickNext'); });

        /*
        ItemProtoDOM = $('#day-item-PROTO').clone();
        $('#day-item-PROTO').remove();
        ItemProtoDOM.removeAttr('id');
        ItemProtoDOM.removeAttr('style');
        */
    },

    initItems: function() {
        ItemDatas = (WeatherStore.getTwoWeeksData()).periods;

        for (var idx= 0, len=ItemDatas.length; idx<len; idx++) {
            var ItemView = new _DayItemView(DateSelectorDOM.children().find('[idx=' + idx +']'));
            ItemView.initialize(ItemDatas[idx]);
        }
        DateSelectorDOM.slick('slickGoTo', 0);
    },

    subscribeActiveApp: AppFlowController.addSubscribe(
        Constants.FlowID.ACTIVE_APP,
        function() {
            DateSelectorDOM.slick('slickGoTo', 0);
        }
    )
};

module.exports = DateSelector;