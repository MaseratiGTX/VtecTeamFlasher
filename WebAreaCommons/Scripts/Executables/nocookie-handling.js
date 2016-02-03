if (CookieHelper.IsCookieDisabled()) {
    $.styles.insertRule(['.page'], 'display: none');
    $.styles.insertRule(['.nocookie'], 'display: block');
} else {
    $.styles.insertRule(['.page'], 'display: block');
    $.styles.insertRule(['.nocookie'], 'display: none');
}
