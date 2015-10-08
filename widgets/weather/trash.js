$('.start').click(function () {
    $('.sun-animation').css('width', '72%');
    $('.sun-symbol-path').css('-webkit-transform', 'rotateZ(27deg)');
    // TODO: mention that this isn't nice
    // city.find('.sunmoon .sun-animation').css('-webkit-transform', 'scaleX(50)');
    return false;
});

$('.reset').click(function () {
    $('.sun-animation').css('width', '0%');
    $('.sun-symbol-path').css('-webkit-transform', 'rotateZ(-75deg)');
    return false;
});