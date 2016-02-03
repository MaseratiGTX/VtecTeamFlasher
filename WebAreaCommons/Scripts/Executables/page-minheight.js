function StretchPageContentToFitWindow() {
    $('.page-content').ConsideringBaseElement(".page").StretchToFitWindow(350);
}

$(document).ready(function () {
    StretchPageContentToFitWindow();

    $(window).resize(function () {
        StretchPageContentToFitWindow();
    });
});
