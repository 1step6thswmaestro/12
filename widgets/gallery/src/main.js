'use strict';

require('./utils/PlatformCommands')();

$(document).ready(function() {
    var liveTiles = $('#component-live-tiles');

    liveTiles.find('.tile-item').not('.exclude').liveTile();
});