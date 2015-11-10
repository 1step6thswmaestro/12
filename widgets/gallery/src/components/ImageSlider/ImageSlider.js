var Flowing = require('../../controller/AppFlowController');
var Constants = require('../../constants/Constants');

function activeComponent() {
    Screen
        .removeAttr('style')
        .css('opacity', 0)
        .animate({
            opacity: 1
        }, 1000, 'swing');

    setTimeout(function() {
        selectedImage.data('owlCarousel').reinit({
            singleItem : true,
            slideSpeed : 1000,
            pagination: false,
            afterAction : syncPosition,
            responsiveRefreshRate : 200,
            autoPlay: false
        });

        selector.data('owlCarousel').reinit({
            items : 5,
            itemsDesktop      : [1199,5],
            itemsDesktopSmall     : [979,5],
            itemsTablet       : [768,5],
            itemsMobile       : [479,5],
            pagination: true,
            responsiveRefreshRate : 100,
            autoPlay: false,
            afterInit : function(el){
                el.find(".owl-item").eq(0).addClass("synced");
            }
        });

        selector.find('.owl-wrapper').css('display', 'flex');
        selectedImage.find('.owl-wrapper').css('display', 'flex');
    }, 1000);

    selector.on('click', '.owl-item', function(e) {
        e.preventDefault();
        var num = $(this).data('owlItem');
        selectedImage.trigger('owl.goTo', num);
    });
}

function disableComponent() {
    Screen
        .animate({
            opacity: 0
        }, 650, 'swing', function() {
            Screen.attr('style', "display: none;");
        });
}

function syncPosition(el){
    var current = this.currentItem;
    selector
        .find(".owl-item")
        .removeClass("synced")
        .eq(current)
        .addClass("synced");

}


var Screen;
var DOM;

var selectedImage;
var selector;

var ImageSlider = {
    initialize: function($) {
        Screen = $('#SCREEN_ACTIVE');
        DOM = $('#component-image-slider');

        selectedImage = DOM.find('[component-attr=selected-image]');
        selector = DOM.find('[component-attr=selector]');

        this.btnPrev = DOM.find('[component-attr=btn_prev]');
        this.btnNext = DOM.find('[component-attr=btn_next]');

        this.initSlider();
    },

    initSlider: function() {
        selectedImage.owlCarousel();
        selector.owlCarousel();

        this.btnPrev.on('click tap', function() { selector.trigger('owl.prev'); });
        this.btnNext.on('click tap', function() { selector.trigger('owl.next'); });
    },

    activeApp: Flowing.addSubscribe(
        Constants.FlowID.ACTIVE_APP,
        function() {
            activeComponent();
        }
    ),

    disableApp: Flowing.addSubscribe(
        Constants.FlowID.DISABLE_APP,
        function() {
            disableComponent();
        }
    )
};

module.exports = ImageSlider;