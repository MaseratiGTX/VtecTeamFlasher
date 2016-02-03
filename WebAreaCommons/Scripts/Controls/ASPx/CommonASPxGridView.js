function CommonASPxGridViewDefaults_EditDataRow_OnRowDblClick(s, e) {
    ASPxSmartGridViewDefaults_EditDataRow_OnRowDblClick(s, e);
};

function CommonASPxGridViewDefaults_ExpandCollapseDetailRow_OnRowDblClick(s, e) {
    ASPxSmartGridViewDefaults_ExpandCollapseDetailRow_OnRowDblClick(s, e);
};

function CommonASPxGridViewDefaults_ExpandCollapseRow_OnRowDblClick(s, e) {
    ASPxSmartGridViewDefaults_ExpandCollapseRow_OnRowDblClick(s, e);
};

function CommonASPxGridViewDefaults_EditOrExpandCollapseRow_OnRowDblClick(s, e) {
    ASPxSmartGridViewDefaults_EditOrExpandCollapseRow_OnRowDblClick(s, e);
};

function CommonASPxGridViewDefaults_ExpandChildsFunctionality_OnEditFormInit(s) {
    ASPxControlsHelper.ExpandFunctionality(
        s.GetPopupEditForm().Controls().Except(ASPxClientGridView)
    );
};