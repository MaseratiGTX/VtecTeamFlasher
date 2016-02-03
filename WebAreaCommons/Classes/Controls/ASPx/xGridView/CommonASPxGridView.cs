using System;
using Commons.Helpers.Objects;
using Commons.Localization.Extensions;
using Commons.Validation.Exceptions;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation.ErrorObjects;
using WebAppCommons.Classes.Controls.ASPx.xTextEdit;
using WebAreaCommons.ResourceRepositories;

namespace WebAreaCommons.Classes.Controls.ASPx.xGridView
{
    public class CommonASPxGridView : ASPxSmartGridView
    {
        public CommonASPxGridView()
        {
            #region PROPERTY DEFAULTS

            KeyFieldName = "Id";

            GroupPanelHeaderNoWrap = true;

            #endregion

            #region SETTINGS_COMMAND_BUTTON_DEFAULTS

            var settingsCommandButton = SettingsCommandButton;

                #region EDITBUTTON DEFAULTS

                var settingsCommandEditButton = settingsCommandButton.EditButton;
                    settingsCommandEditButton.ButtonType = GridViewCommandButtonType.Image;
                    settingsCommandEditButton.Text = "Редактировать".Localize();
                    settingsCommandEditButton.Image.Url = WebAreaCommonResources.ProvideURLFor("Images.btnEdit.png");
                    settingsCommandEditButton.Image.ToolTip = "Редактировать запись".Localize();
            
                #endregion

                #region VIEWBUTTON DEFAULTS

                var settingsCommandViewButton = settingsCommandButton.ViewButton;
                    settingsCommandViewButton.ButtonType = GridViewCommandButtonType.Image;
                    settingsCommandViewButton.Text = "Просмотреть".Localize();
                    settingsCommandViewButton.Image.Url = WebAreaCommonResources.ProvideURLFor("Images.btnView.png");
                    settingsCommandViewButton.Image.ToolTip = "Просмотреть запись".Localize();
            
                #endregion

                #region NEWBUTTON DEFAULTS

                var settingsCommandNewButton = settingsCommandButton.NewButton;
                    settingsCommandNewButton.ButtonType = GridViewCommandButtonType.Image;
                    settingsCommandNewButton.Text = "Добавить".Localize(); 
                    settingsCommandNewButton.Image.Url = WebAreaCommonResources.ProvideURLFor("Images.btnNew.png");
                    settingsCommandNewButton.Image.ToolTip = "Добавить запись".Localize();
            
                #endregion

                #region DELETEBUTTON DEFAULTS

                var settingsCommandDeleteButton = settingsCommandButton.DeleteButton;
                    settingsCommandDeleteButton.ButtonType = GridViewCommandButtonType.Image;
                    settingsCommandDeleteButton.Text = "Удалить".Localize();
                    settingsCommandDeleteButton.Image.Url = WebAreaCommonResources.ProvideURLFor("Images.btnDelete.png");
                    settingsCommandDeleteButton.Image.ToolTip = "Удалить запись".Localize();
            
                #endregion

                #region ECBUTTONS DEFAULTS
                
                var settingsExpandCollapseAllButtons = settingsCommandButton.ExpandCollapseAllButtons;

                #region EXPANDALLBUTTON DEFAULTS
                
                var settingsCommandExpandAllButton = settingsExpandCollapseAllButtons.ExpandAllButton;
                    settingsCommandExpandAllButton.ButtonType = GridViewCommandButtonType.Image;
                    settingsCommandExpandAllButton.Text = "Развернуть все".Localize();
                    settingsCommandExpandAllButton.Image.Url = WebAreaCommonResources.ProvideURLFor("Images.btnExpandAll.png");
                    settingsCommandExpandAllButton.Image.UrlDisabled = WebAreaCommonResources.ProvideURLFor("Images.btnExpandAll_Disabled.png");
                
                #endregion
                
                #region BUTTONSEPARATOR DEFAULTS
                
                var settingsCommandButtonSeparator = settingsExpandCollapseAllButtons.ButtonSeparator;
                    settingsCommandButtonSeparator.SeparatorType = ASPxSmartGridViewCommandButtonSeparatorType.Image;
                    settingsCommandButtonSeparator.Image.Url = WebAreaCommonResources.ProvideURLFor("Images.btnSeparator.png");
                
                #endregion

                #region COLLAPSEALLBUTTON DEFAULTS
                
                var settingsCommandCollapseAllButton = settingsExpandCollapseAllButtons.CollapseAllButton;
                    settingsCommandCollapseAllButton.ButtonType = GridViewCommandButtonType.Image;
                    settingsCommandCollapseAllButton.Text = "Свернуть все".Localize();
                    settingsCommandCollapseAllButton.Image.Url = WebAreaCommonResources.ProvideURLFor("Images.btnCollapseAll.png");
                    settingsCommandCollapseAllButton.Image.UrlDisabled = WebAreaCommonResources.ProvideURLFor("Images.btnCollapseAll_Disabled.png");
                
                #endregion


                #endregion

            #endregion

            #region SETTINGS_TEXT DEFAULTS

                var settingsText = SettingsText;
                    settingsText.EmptyDataRow = "Нет записей для отображения".Localize();
                    settingsText.ConfirmDelete = "Вы действительно хотите удалить данную запись?".Localize();
                    settingsText.CommandCancel = "Отмена".Localize();
                    settingsText.GroupContinuedOnNextPage = "(продолжение на следующей странице...)".Localize();
                    settingsText.GroupPanel = "Перетащите сюда заголовок колонки для группировки данных".Localize();
                    settingsText.GroupItemCountFormat = "количество записей: {0:d}".Localize();
                    settingsText.NullGroupDisplayText = "значение не указано".Localize();
                    settingsText.SearchResultsSummary = "По критериям поиска: {0} было найдено {1} записи(ей)".Localize();
                    settingsText.SearchResultsEmptyDetails = "'критерии поиска не указаны'".Localize();
                    settingsText.ConfirmEditFormWindowUnload = "Открыта форма редактирования".Localize();
                    settingsText.SourceElementNotFound = "Не можем осуществить запрашиваемое действие, так как искомая запись уже удалена.".Localize();
                    settingsText.CallbackTargetNotFound = "Не может осуществить запрашиваемое действие с подчиненным гридом, так как редактируемая вами запись основного грида скорее всего уже удалена.\r\n\r\nПерегрузить основной грид сейчас?".Localize();

                #region INIT_NEW_ROW DEFAULTS
            
                var settingsTextInitNewRow = settingsText.InitNewRow;
                    settingsTextInitNewRow.CommandUpdate = "Добавить".Localize();

                #endregion

                #region START_ROW_EDITING DEFAULTS
            
                var settingsTextStartRowEditing = settingsText.StartRowEditing;
                    settingsTextStartRowEditing.CommandUpdate = "Сохранить".Localize();

                #endregion

            #endregion

            #region SETTINGS_LOADING_PANEL DEFAULTS

                var settingsLoadingPanel = SettingsLoadingPanel;
                settingsLoadingPanel.Text = "Загрузка...".Localize();

            #endregion

            #region SETTINGS_PAGER DEFAULTS

            var settingsPager = SettingsPager;

                #region SUMMARY DEFAULTS
                
                var settingsPagerSummary = settingsPager.Summary;
                    settingsPagerSummary.AllPagesText = "Страница: {0} - {1} (всего строк {2})".Localize();
                    settingsPagerSummary.Text = "Страница: {0} - {1} (всего строк {2})".Localize();
                
                #endregion

            #endregion
        }


        protected override void PrepareRootTableStyle(AppearanceStyle style)
        {
            base.PrepareRootTableStyle(style);

            style.CssClass = RenderUtils.CombineCssClasses(style.CssClass, "CommonASPxGridView");
        }


        protected override void RegisterIncludeScripts()
        {
            base.RegisterIncludeScripts();

            RegisterIncludeScript(typeof(CommonASPxGridView), "WebAreaCommons.Scripts.Controls.ASPx.CommonASPxGridView.js");
        }



        protected override ASPxSmartGridViewErrorHelper CreateErrorHelper()
        {
            return base.CreateErrorHelper().AddConvertionFuction(
                (Func<ValidationException, SourceElementValidationErrorObject>) (
                    x => new SourceElementValidationErrorObject 
                    {
                        Message = x.Message,
                        FieldName = x.FieldName
                    }
                )
            );
        }

        
        protected override void OnEditorInitialize_BaseImplementation(ASPxGridViewEditorEventArgs e)
        {
            base.OnEditorInitialize_BaseImplementation(e);

            
            var aspxTextEdit = e.Editor as ASPxTextEdit;
            
            if (aspxTextEdit != null)
            {
                if (aspxTextEdit.NullText().IsEmpty())
                {
                    aspxTextEdit.NullText("значение не указано".Localize());
                }
            }
        }

        protected override void OnCustomErrorText_BaseImplementation(ASPxGridViewCustomErrorTextEventArgs e)
        {
            if (e.Exception != null && e.Exception.InnerException != null)
            {
                e.ErrorText = e.Exception.InnerException.Message;
            }
        }
    }
}