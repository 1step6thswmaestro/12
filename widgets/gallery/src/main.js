'use strict';

$(document).ready(function() {
    var liveTiles = $('#component-live-tiles');

    liveTiles.find('.tile-item').not('.exclude').liveTile();
});