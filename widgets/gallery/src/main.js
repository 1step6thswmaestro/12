'use strict';

require('./utils/PlatformCommands')();
require('./stores/PictureStore');

var ImageSlider = require('./components/ImageSlider/ImageSlider');
var LiveTiles = require('./components/LiveTiles/LiveTiles');

$(document).ready(function() {
    var liveTiles = $('#component-live-tiles');

    liveTiles.find('.tile-item').not('.exclude').liveTile();

    LiveTiles.initialize($);
    ImageSlider.initialize($);
});