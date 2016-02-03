/* Common Functions */

function SetMainLoadingPanelText(text) {
    MainLoadingPanel.SetText(text + '...');

    if (MainLoadingPanel.shown) {
        MainLoadingPanel.SetLoadingPanelPosAndSize();
        MainLoadingPanel.SetLoadingDivPosAndSize();
    }
}

function ShowMainLoadingPanel() {
    MainLoadingPanel.Show();
}

function HideMainLoadingPanel() {
    MainLoadingPanel.Hide();
}



/* Login Page Functions */

function RaiseButtonClickOnEnter(event, buttonName) {
    var key = event.htmlEvent.keyCode;

    switch (key) {
        case ASPxKey.Enter:
            try {
                var button = eval(buttonName);
                button.DoClick();

                event.htmlEvent.preventDefault();
            }
            catch (e) {
                alert(e);
            }
        break;
    }

    return false;
}