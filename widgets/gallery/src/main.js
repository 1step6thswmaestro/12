'use strict';

require('./utils/PlatformCommands')();
require('./stores/PictureStore');

var ImageSlider = require('./components/ImageSlider/ImageSlider');
var LiveTiles = require('./components/LiveTiles/LiveTiles');

/**
 * 이 클래스는 컴포넌트 모듈을 초기화하기 위한 클래스입니다.
 * 이 클래스는 DOM 트리 구축이 완료 되었을 때 호출됩니다.
 *
 * @version 151028
 * @author 나석주
 */
$(document).ready(function() {
    var liveTiles = $('#component-live-tiles');

    liveTiles.find('.tile-item').not('.exclude').liveTile();

    LiveTiles.initialize($);
    ImageSlider.initialize($);
});
