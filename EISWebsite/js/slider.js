/*  ::

    :: Theme        : Jets
    :: Theme URI    : http://labs.funcoders.com/html/Jets

    :: File         : slider.js
    :: About        : Revolution slider
    :: Version      : 1.4.1

::  */
$(function () {
    $('#page-slider').revolution({
        delay           : 9000,
        startheight     : 500,
        hideThumbs      : 10,

        touchenabled    : 'on',
        onHoverStop     : 'on',
        startwidth      : $('body').hasClass('w970') ? 960 : 1170,

        navOffsetHorizontal : 0,
        navOffsetVertical   : 0,

        minFullScreenHeight : '320',

        fullWidth       : 'on'
    }).bind('revolution.slide.onloaded', function (e, data) {
        $(this).parent().css({
            background  : 'transparent',
            height      : 'auto',
            overflow    : 'visible'
        }).children().animate({opacity : 1}, 500);
    });
});