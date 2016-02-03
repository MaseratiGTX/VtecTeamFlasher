$(document).ready(function () {
    DblScrollHelper.initialize();

    $(window).resize(function () {
        DblScrollHelper.redrawScrollBars();
    });
})