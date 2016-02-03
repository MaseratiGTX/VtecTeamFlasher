function FIX_WINDOW_SCROLL_BLINKING() {
    var $body = $('body');

    if ($(window).width() < $body.width()) {
        $body.css('overflowX', 'visible');
    } else {
        $body.css('overflowX', 'hidden');
    }
}

$(document).ready(function () {
    FIX_WINDOW_SCROLL_BLINKING();

    $(window).resize(function () {
        FIX_WINDOW_SCROLL_BLINKING();
    });
});

