using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Commons.DataCache;
using Commons.Helpers.Collections.Specialized;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using Commons.Reflections;
using Commons.Reflections.PropertyValues.Fetching;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Internal;
using DevExpress.Web.ASPxGridView.Rendering;
using DevExpress.Web.Data;
using WebAppCommons.Classes.Controls.ASPx.xCriteriaOperator;
using WebAppCommons.Classes.Controls.ASPx.xGridView;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Columns;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Events.Args;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Events.Handlers;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.EditorValues;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewDataColumns;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Internal;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation.Helpers.Items;
using WebAppCommons.Classes.Controls.CallbackRegistration;
using WebAppCommons.Classes.Controls.IListServer.Implementation;
using WebAppCommons.Classes.Helpers;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView
{
    public class ASPxSmartGridView : ASPxGridView
    {
        private static readonly object htmlDataRowPrepared = new object();
        private static readonly object performSearching = new object();
        private static readonly object cancelSearching = new object();

        protected ASPxSmartGridViewErrorHelper errorHelper;
        
        protected ASPxSmartGridViewCommandButtonSettings settingsCommandButtonInstance;


        protected internal new WebDataProxy DataProxy
        {
            get { return base.DataProxy; }
        }

        protected internal new ASPxSmartGridViewContainerControl ContainerControl
        {
            get { return (ASPxSmartGridViewContainerControl) base.ContainerControl; }
        }

        protected internal new bool IsErrorOnCallbackCore
        {
            get { return base.IsErrorOnCallbackCore; }
        }

        protected ArrayList PageKeyValuesLoadedState { get; set; }

        protected bool PreviouslyHasBindedData
        {
            get { return PageKeyValuesLoadedState.IsNotEmpty(); }
        }


        [NotifyParentProperty(true)]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return GetBoolProperty("ReadOnly", false); }
            set { SetBoolProperty("ReadOnly", false, value); }
        }

        [AutoFormatDisable]
        [DefaultValue(false)]
        public bool ShouldDisplayEmptySearch
        {
            get { return GetBoolProperty("ShouldDisplayEmptySearch", false); }
            set { SetBoolProperty("ShouldDisplayEmptySearch", false, value); }
        }

        [AutoFormatDisable]
        [DefaultValue(false)]
        public bool GroupPanelHeaderNoWrap
        {
            get { return GetBoolProperty("GroupPanelHeaderNoWrap", false); }
            set { SetBoolProperty("GroupPanelHeaderNoWrap", false, value); }
        }

        public new ASPxSmartGridViewTextSettings SettingsText
        {
            get { return (ASPxSmartGridViewTextSettings) base.SettingsText; }
        }

        public new ASPxSmartGridViewPagerSettings SettingsPager
        {
            get { return (ASPxSmartGridViewPagerSettings) base.SettingsPager; }
        }

        public new ASPxSmartGridViewBehaviorSettings SettingsBehavior
        {
            get { return (ASPxSmartGridViewBehaviorSettings) base.SettingsBehavior; }
        }

        public new ASPxSmartGridViewCommandButtonSettings SettingsCommandButton
        {
            get { return settingsCommandButtonInstance ?? (settingsCommandButtonInstance = new ASPxSmartGridViewCommandButtonSettings(base.SettingsCommandButton)); }
        }


        public new ASPxSmartGridViewClientSideEvents ClientSideEvents
        {
            get { return (ASPxSmartGridViewClientSideEvents)base.ClientSideEvents; }
        }



        [Category("Action")]
        public event ASPxHtmlDataRowPreparedEventHandler HtmlDataRowPrepared
        {
            add { Events.AddHandler(htmlDataRowPrepared, value); }
            remove { Events.RemoveHandler(htmlDataRowPrepared, value); }
        }

        [Category("Action")]
        public event ASPxPerformSearchingEventHandler PerformSearching
        {
            add { Events.AddHandler(performSearching, value); }
            remove { Events.RemoveHandler(performSearching, value); }
        }

        [Category("Action")]
        public event ASPxCancelSearchingEventHandler CancelSearching
        {
            add { Events.AddHandler(cancelSearching, value); }
            remove { Events.RemoveHandler(cancelSearching, value); }
        }

        protected ControlCallbackRegistrator<ASPxGridViewCommandButtonCallbackEventArgs> CommandButtonCallbackRegistrator { get; set; }
        protected ControlCallbackRegistrator<ASPxGridViewCustomButtonCallbackEventArgs> CustomButtonCallbackRegistrator { get; set; }


        protected ASPxSmartGridView()
        {
            CommandButtonCallbackRegistrator = new ControlCallbackRegistrator<ASPxGridViewCommandButtonCallbackEventArgs>(this);
            CustomButtonCallbackRegistrator = new ControlCallbackRegistrator<ASPxGridViewCustomButtonCallbackEventArgs>(this);

            #region PROPERTY DEFAULTS

            AutoGenerateColumns = false;
            EnableRowsCache = false;
            
            #endregion

            #region STYLES DEFAULTS

            var headerStyle = Styles.Header;
                headerStyle.Wrap = DefaultBoolean.True;
                headerStyle.HorizontalAlign = HorizontalAlign.Center;
                headerStyle.VerticalAlign = VerticalAlign.Middle;

            var cellStyle = Styles.Cell;
                cellStyle.Wrap = DefaultBoolean.False;
                cellStyle.VerticalAlign = VerticalAlign.Middle;

            var editFormColumnCaptionStyle = Styles.EditFormColumnCaption;
                editFormColumnCaptionStyle.HorizontalAlign = HorizontalAlign.Right;

            #endregion            
            
            #region SETTINGS DEFAULTS

            var settings = Settings;
                settings.ShowStatusBar = GridViewStatusBarMode.Visible;

            #endregion

            #region SETTINGS_BEHAVIOR DEFAULTS

            var settingsBehavior = SettingsBehavior;
                settingsBehavior.AutoExpandAllGroups = true;
                settingsBehavior.ConfirmDelete = true;
                settingsBehavior.ConfirmEditFormWindowUnload = true;

            #endregion

            #region SETTINGS_EDITING DEFAULTS

            var settingsEditing = SettingsEditing;
                settingsEditing.Mode = GridViewEditingMode.PopupEditForm;
                settingsEditing.EditFormColumnCount = 1;

            #endregion

            #region SETTINGS_POPUP DEFAULTS

            var settingsPopup = SettingsPopup;

                #region EDITFORM DEFAULTS

                var editFormSettingsPopup = settingsPopup.EditForm;
                    editFormSettingsPopup.Modal = true;
                    editFormSettingsPopup.AllowResize = false;
                    editFormSettingsPopup.Width = Unit.Pixel(500);
                    editFormSettingsPopup.HorizontalAlign = PopupHorizontalAlign.WindowCenter;
                    editFormSettingsPopup.VerticalAlign = PopupVerticalAlign.WindowCenter;
                    editFormSettingsPopup.HorizontalOffset = 0;
                    editFormSettingsPopup.VerticalOffset = 0;

                #endregion

            #endregion

            #region SETTINGS_PAGER DEFAULTS

            var settingsPager = SettingsPager;
                settingsPager.Mode = GridViewPagerMode.ShowPager;
                settingsPager.PageSize = 20;
                settingsPager.Position = PagerPosition.TopAndBottom;

            #endregion
        }


        
        protected override void OnInit(EventArgs e)
        {
            ValidateSettingsState();
            InitializeDefaultSummaries();

            base.OnInit(e);
        }


        protected virtual void ValidateSettingsState()
        {
            ValidateColumnsAutosizeState();
        }

        protected virtual void ValidateColumnsAutosizeState()
        {
            if (SettingsBehavior.ColumnResizeMode != ColumnResizeMode.Disabled)
            {
                if (AllColumns.OfType<IAutosizeable>().Any(x => x.Autosize))
                {
                    throw new NotSupportedException("Columns resize is enabled: columns autosize is not supporting");
                }
            }
        }


        protected virtual void InitializeDefaultSummaries()
        {
            InitializeGroupItemCountSummary();
        }

        protected virtual void InitializeGroupItemCountSummary()
        {
            if(SettingsText.GroupItemCountFormat.IsEmpty()) return;

            GroupSummary.Add(
                new ASPxSummaryItem
                {
                    FieldName = KeyFieldName,
                    SummaryType = SummaryItemType.Count,
                    DisplayFormat = SettingsText.GroupItemCountFormat,
                }
            );
        }


        protected override void LoadGridControlState(string pageSelectionResult, string pageKeyValues, string columnResizingResult, string endlessPagingState, string batchEditClientState)
        {
            base.LoadGridControlState(pageSelectionResult, pageKeyValues, columnResizingResult, endlessPagingState, batchEditClientState);

            var arrayList = new ArrayList();
            
            if (pageKeyValues.IsNotEmpty() && pageKeyValues.StartsWith("["))
            {
                arrayList = HtmlConvertor.FromJSON<ArrayList>(pageKeyValues);
            }

            PageKeyValuesLoadedState = DataProxy.GetKeyValuesFromScript(arrayList);
        }



        protected override ASPxGridViewTextSettings CreateSettingsText()
        {
            return new ASPxSmartGridViewTextSettings(this);
        }

        protected override ASPxGridViewPagerSettings CreateSettingsPager()
        {
            return new ASPxSmartGridViewPagerSettings(this);
        }

        protected override ASPxGridViewBehaviorSettings CreateBehaviorSettings()
        {
            return new ASPxSmartGridViewBehaviorSettings(this);
        }



        protected internal new virtual void OnBeforeCreateControlHierarchy()
        {
            base.OnBeforeCreateControlHierarchy();
        }


        protected virtual ASPxSmartGridViewErrorHelper CreateErrorHelper()
        {
            return new ASPxSmartGridViewErrorHelper();
        }

        protected override GridViewEndlessPagingHelper CreateEndlessPagingHelper()
        {
            return new ASPxSmartGridViewEndlessPagingHelper(this);
        }


        protected override GridViewContainerControl CreateContainerControl()
        {
            return new ASPxSmartGridViewContainerControl(this);
        }


        protected ASPxSmartGridViewErrorHelper ErrorHelper
        {
            get { return errorHelper ?? (errorHelper = CreateErrorHelper()); }
        }

        protected internal new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }

        protected internal new GridViewColumnHelper ColumnHelper
        {
            get { return base.ColumnHelper; }
        }


        protected override ASPxGridViewRenderHelper CreateRenderHelper()
        {
            return new ASPxSmartGridViewRenderHelper(this);
        }

        internal AppearanceStyle PrepareEnabledRootTableStyle_Internal(AppearanceStyle style)
        {
            PrepareEnabledRootTableStyle(style);

            return style;
        }

        internal AppearanceStyle PrepareDisabledRootTableStyle_Internal(AppearanceStyle style)
        {
            PrepareDisabledRootTableStyle(style);

            return style;
        }


        
        protected virtual void PrepareEnabledRootTableStyle(AppearanceStyle style)
        {
        }

        protected virtual void PrepareDisabledRootTableStyle(AppearanceStyle style)
        {
        }

        protected virtual void PrepareRootTableStyle(AppearanceStyle style)
        {
            style.CssClass = RenderUtils.CombineCssClasses(style.CssClass, "dxsgv");
        }


        protected override void RegisterDefaultRenderCssFile()
        {
            base.RegisterDefaultRenderCssFile();

            ResourceManager.RegisterCssResource(Page, typeof(ASPxSmartGridView), "WebAppCommons.Styles.Controls.ASPx.ASPxSmartGridView.css");
        }



        protected override ClientSideEventsBase CreateClientSideEvents()
        {
            return new ASPxSmartGridViewClientSideEvents();
        }

        protected override string GetClientObjectClassName()
        {
            return "ASPxClientSmartGridView";
        }

        protected override void RegisterIncludeScripts()
        {
            base.RegisterIncludeScripts();

            RegisterIncludeScript(typeof(ASPxSmartGridView), "WebAppCommons.Scripts.Controls.ASPx.ASPxClientUtils.js");
            RegisterIncludeScript(typeof(ASPxSmartGridView), "WebAppCommons.Scripts.Controls.ASPx.ASPxFunctionsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSmartGridView), "WebAppCommons.Scripts.Controls.ASPx.ASPxCollectionsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSmartGridView), "WebAppCommons.Scripts.Controls.ASPx.ASPxControlsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSmartGridView), "WebAppCommons.Scripts.Controls.ASPx.ASPxSmartKbdHelper.js");
            RegisterIncludeScript(typeof(ASPxSmartGridView), "WebAppCommons.Scripts.Controls.ASPx.ASPxWindowHelper.js");
            RegisterIncludeScript(typeof(ASPxSmartGridView), "WebAppCommons.Scripts.Controls.ASPx.ASPxSmartGridView.js");
        }


        protected override void InitializeClientObjectScript(StringBuilder stb, string localVarName, string clientID)
        {
            base.InitializeClientObjectScript(stb, localVarName, clientID);

            if (ReadOnly)
                stb.AppendFormat("{0}.readOnly={1};\n", localVarName, ReadOnly.ToScript());

            stb.AppendFormat("{0}.isSearchPerformed={1};\n", localVarName, SearchPerformed.ToScript());
            stb.AppendFormat("{0}.hasDetailRows={1};\n", localVarName, SettingsDetail.ShowDetailRow.ToScript());

            if (SettingsBehavior.ConfirmEditFormWindowUnload)
                stb.AppendFormat("{0}.confirmEditFormWindowUnload={1};\n", localVarName, SettingsText.ConfirmEditFormWindowUnload.ToScript());

            stb.AppendFormat("{0}.sourceElementNotFound={1};\n", localVarName, SettingsText.SourceElementNotFound.ToScript());
            stb.AppendFormat("{0}.callbackTargetNotFound={1};\n", localVarName, SettingsText.CallbackTargetNotFound.ToScript());
            
            GenerateClientVisibleColumns(stb, localVarName);
        }

        protected virtual void GenerateClientVisibleColumns(StringBuilder stb, string localVarName)
        {
            var clientGridViewColumns = localVarName + ".columns";


            var result = AllColumns.Where(x => x.Visible);

            if (Settings.ShowGroupedColumns == false)
            {
                result = result.Where(x => x.NotGrouped());
            }

            result = result.OrderBy(x => x.VisibleIndex);


            var resultArrayScript = result
                .ToObjectArrayScript(
                    x => "ASPxClientGridViewVisibleColumn".CreateNewInstanceScript(
                        clientGridViewColumns.CreateItemSelectorScript(x.Index),
                        x.VisibleIndex.ToScript()
                    )
                );

            stb.AppendFormat("{0}.visibleColumns = {1};\n", localVarName, resultArrayScript);
        }



        protected override void PrepareControlHierarchy()
        {
            RenderUtils.AssignAttributes(this, RootTable);

            if (KeyboardSupport) RootTable.AccessKey = string.Empty;
            
            RenderUtils.SetVisibility(RootTable, IsClientVisible(), true);


            var appearanceStyle = IsEnabled() ? RenderHelper.GetRootTableStyle() : RenderHelper.GetDisabledRootTableStyle();
                
            PrepareRootTableStyle(appearanceStyle);
            
                appearanceStyle.AssignToControl(RootTable, false);
                appearanceStyle.Paddings.AssignToControl(RootCell);


            if (Browser.IsIE && Browser.Version >= 8.0)
            {
                var paddings = new Paddings(0, 0, 0, 0);
                paddings.CopyFrom(appearanceStyle.Paddings);
                paddings.AssignToControl(RootCell);
            }
            
            RootTable.CellPadding = 0;
            RootTable.CellSpacing = 0;
            RootTable.Width = RenderHelper.GetRootTableWidth();
        }



        protected internal bool IsSwipeGesturesEnabled_Internal()
        {
            return base.IsSwipeGesturesEnabled();
        }



        protected virtual bool THIS_IS_FOREIGN_CALLBACK()
        {
            return Page.IS_FOREIGN_CALLBACK_FOR(this);
        }



        protected virtual internal string GetSRSummaryControlID()
        {
            return "SBSRS";
        }



        protected override void RegisterCallBacks(Dictionary<string, ASPxGridCallBackMethod> callBacks)
        {
            base.RegisterCallBacks(callBacks);

            callBacks["STARTEDIT"] = CBStartEdit;
            callBacks["ADDNEWROW"] = CBAddNewRow;
            callBacks["DELETEROW"] = CBDeleteRow;
            callBacks["REFRESH"] = CBRefresh;

            callBacks["PERFORMSEARCH"] = CBPerformSearch;
            callBacks["CANCELSEARCH"] = CBCancelSearch;
        }


        protected new void CBStartEdit(string[] args)
        {
            LoadDataIfNotBinded(true);
            
            var keyValueFromScript = DataProxy.GetKeyValueFromScript(args[0]);
            
            if (keyValueFromScript == null) return;

            var visibleIndex = FindVisibleIndexByKeyValue(keyValueFromScript);

            if (HasEventMarker(args))
            {
                CommandButtonCallbackRegistrator.Register(
                    new ASPxGridViewCommandButtonCallbackEventArgs(
                        ColumnCommandButtonType.Edit,
                        visibleIndex
                    )
                );
            }

            StartEdit(visibleIndex);
        }

        protected new void CBAddNewRow(string[] args)
        {
            if (HasEventMarker(args))
            {
                CommandButtonCallbackRegistrator.Register(
                    new ASPxGridViewCommandButtonCallbackEventArgs(
                        ColumnCommandButtonType.New,
                        ParseAddNewRowArguments(args)
                    )
                );
            }

            AddNewRow();
        }

        protected override void CBDeleteRow(string[] args)
        {
            LoadDataIfNotBinded(true);
            
            var keyValueFromScript = DataProxy.GetKeyValueFromScript(args[0]);
            
            if (keyValueFromScript == null) return;

            var visibleIndex = FindVisibleIndexByKeyValue(keyValueFromScript);

            if (HasEventMarker(args))
            {
                CommandButtonCallbackRegistrator.Register(
                    new ASPxGridViewCommandButtonCallbackEventArgs(
                        ColumnCommandButtonType.Delete,
                        visibleIndex
                    )
                );
            }

            DeleteRow(visibleIndex);
        }

        
        protected new void CBRefresh(string[] args)
        {
            DataBind();
            
            if (RenderHelper.UseEndlessPaging)
            {
                EndlessPagingHelper.LoadFirstPage();
            }

            if (SettingsBehavior.AutoExpandAllGroups && PreviouslyHasBindedData == false)
            {
                ExpandAll();
            }
        }
       

        protected virtual void CBPerformSearch(string[] args)
        {
            PerformSearch();
        }

        protected virtual void CBCancelSearch(string[] args)
        {
            CancelSearch();
        }


        protected bool HasEventMarker(string[] args)
        {
            return args.LastOrDefault().SafelyParseBool() ?? false;
        }

        protected int ParseAddNewRowArguments(string[] args)
        {
            return args.FirstOrDefault().SafelyParseInt() ?? InvalidRowIndex;
        }


        
        public int GetDataRowCount()
        {
            return ASPxGridViewExtensions.GetDataRowCount(this);
        }


        protected internal bool ShouldDisplaySearch
        {
            get { return SearchPerformed || ShouldDisplayEmptySearch; }
        }

        public bool SearchPerformed
        {
            get { return CallbackState.Get("SearchPerformed", false); }

            set
            {
                if (SearchPerformed == value) return;

                CallbackState.Put("SearchPerformed", value);
            }
        }

        public string SearchDetails
        {
            get { return CallbackState.Get("SearchDetails", SettingsText.SearchResultsEmptyDetails); }
            
            set
            {
                if(SearchDetails == value) return;

                CallbackState.Put("SearchDetails", value);
            }
        }


        public void PerformSearch()
        {
            var eventArgs = new ASPxPerformSearchingEventArgs();

            RaisePerformSearching(eventArgs);

            if(eventArgs.Cancel) return;

            FilterExpression = eventArgs.CalculateFilterExpression();
            DataBind();

            SearchDetails = eventArgs.CalculateSearchDetails().IfEmpty(SettingsText.SearchResultsEmptyDetails);
            SearchPerformed = true;
        }

        public void CancelSearch()
        {
            var eventArgs = new ASPxCancelSearchingEventArgs();

            RaiseCancelSearching(eventArgs);

            if(eventArgs.Cancel) return;

            FilterExpression = eventArgs.CalculateFilterExpression();
            DataBind();

            SearchDetails = eventArgs.CalculateSearchDetails().IfEmpty(SettingsText.SearchResultsEmptyDetails);
            SearchPerformed = false;
        }


        
        protected override void SetEditorValues(string editorValues, bool canIgnoreInvalidValues)
        {
            if (string.IsNullOrEmpty(editorValues)) return;
            
            var editorValuesReader = new SmartGridViewCallBackEditorValuesReader(editorValues);
                editorValuesReader.Proccess();
            
            if (editorValuesReader.Values.Count == 0) return;

            var values = new Dictionary<string, object>();
            
            foreach (var editorValueInfo in editorValuesReader.Values)
            {
                var gridViewDataColumn = AllColumns[editorValueInfo.ColumnIndex] as GridViewDataColumn;

                if (gridViewDataColumn != null && !string.IsNullOrEmpty(gridViewDataColumn.FieldName))
                {
                    var fieldValue = editorValueInfo.Value;

                    var columnDataType = gridViewDataColumn._GetDataType();

                    if (columnDataType.IsEnumeration())
                    {
                        if (fieldValue is string)
                        {
                            fieldValue = new[] { (string) fieldValue };
                        }
                    }

                    values[gridViewDataColumn.FieldName] = fieldValue;
                }
            }
            
            DataProxy.SetEditorValues(values, canIgnoreInvalidValues);
        }



        internal void RaiseCommandButtonInitialize_Internal(ASPxGridViewCommandButtonEventArgs e)
        {
            RaiseCommandButtonInitialize(e);
        }

        internal void RaiseCustomButtonInitialize_Internal(ASPxGridViewCustomButtonEventArgs e)
        {
            RaiseCustomButtonInitialize(e);
        }

        internal void RaiseHtmlCommandCellPrepared_Internal(GridViewTableBaseCommandCell cell)
        {
            RaiseHtmlCommandCellPrepared(cell);
        }

        internal void RaiseEditorInitialize_Internal(ASPxGridViewEditorEventArgs e)
        {
            RaiseEditorInitialize(e);
        }



        protected override void RaiseHtmlRowPrepared(GridViewTableRow row)
        {
            if (row.RowType == GridViewRowType.Data)
            {
                RaiseHtmlDataRowPrepared(row);
            }

            base.RaiseHtmlRowPrepared(row);
        }

        protected virtual void RaiseHtmlDataRowPrepared(GridViewTableRow row)
        {
            var eventHandler = (ASPxHtmlDataRowPreparedEventHandler) Events[htmlDataRowPrepared];

            if (eventHandler != null)
            {
                eventHandler(this, new ASPxGridViewTableDataRowEventArgs(row));
            }
        }


        protected override void RaiseCustomGroupDisplayText(ASPxGridViewColumnDisplayTextEventArgs e)
        {
            OnBeforeCustomGroupDisplayText_BaseImplementation(e);
            
            base.RaiseCustomGroupDisplayText(e);

            OnAfterCustomGroupDisplayText_BaseImplementation(e);
        }


        protected override void RaiseInitNewRow(ASPxDataInitNewRowEventArgs e)
        {
            OnInitNewRow_BaseImplementation(e);

            base.RaiseInitNewRow(e);
        }

        protected override void RaiseStartEditingRow(ASPxStartRowEditingEventArgs e)
        {
            OnStartRowEditing_BaseImplementation(e);

            base.RaiseStartEditingRow(e);
        }


        protected override void RaiseEditorInitialize(ASPxGridViewEditorEventArgs e)
        {
            OnEditorInitialize_BaseImplementation(e);

            base.RaiseEditorInitialize(e);
        }


        protected override string RaiseCustomErrorText(ASPxGridViewCustomErrorTextEventArgs e)
        {
            var processingResult = ErrorHelper.Process(e.Exception);

            if (processingResult != null) return processingResult;
            
            OnCustomErrorText_BaseImplementation(e);
            
            return base.RaiseCustomErrorText(e);
        }


        protected override void RaiseRowInserting(ASPxDataInsertingEventArgs e)
        {
            OnBeforeRowInserting_BaseImplementation(e);

            base.RaiseRowInserting(e);

            OnAfterRowInserting_BaseImplementation(e);
        }

        protected override void RaiseRowUpdating(ASPxDataUpdatingEventArgs e)
        {
            OnBeforeRowUpdating_BaseImplementation(e);

            base.RaiseRowUpdating(e);

            OnAfterRowUpdating_BaseImplementation(e);
        }

        protected override void RaiseRowDeleting(ASPxDataDeletingEventArgs e)
        {
            OnBeforeRowDeleting_BaseImplementation(e);

            base.RaiseRowDeleting(e);

            OnAfterRowDeleting_BaseImplementation(e);
        }


        protected virtual void RaisePerformSearching(ASPxPerformSearchingEventArgs e)
        {
            var eventHandler = (ASPxPerformSearchingEventHandler) Events[performSearching];
            
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        protected virtual void RaiseCancelSearching(ASPxCancelSearchingEventArgs e)
        {
            var eventHandler = (ASPxCancelSearchingEventHandler) Events[cancelSearching];
            
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }


        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (THIS_IS_FOREIGN_CALLBACK()) return;

            DataBind();
        }


        
        protected virtual void OnBeforeCustomGroupDisplayText_BaseImplementation(ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (SettingsText.NullGroupDisplayText.IsEmpty()) return;

            if (e.Value == null)
            {
                e.DisplayText = SettingsText.NullGroupDisplayText;
            }
        }

        protected virtual void OnAfterCustomGroupDisplayText_BaseImplementation(ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Value != null)
            {
                e.DisplayText = SettingsText.GroupDisplayTextFormat.FillWith(e.DisplayText);
            }
        }


        protected virtual void OnInitNewRow_BaseImplementation(ASPxDataInitNewRowEventArgs e)
        {
            if (SettingsText.InitNewRow.CommandUpdate.IsNotEmpty())
            {
                SettingsText.CommandUpdate = SettingsText.InitNewRow.CommandUpdate.Truncate(
                    SettingsText.InitNewRow.CommandUpdateWidth
                );
            }

            if (SettingsText.InitNewRow.PopupEditFormCaption.IsNotEmpty())
            {
                SettingsText.PopupEditFormCaption = SettingsText.InitNewRow.PopupEditFormCaption.Truncate(
                    SettingsText.InitNewRow.PopupEditFormCaptionWidth
                );
            }


            if (this.IsGrouped())
            {
                var lastCallbackOfNewButton = CommandButtonCallbackRegistrator.InCallbacks().FindLastOf(ColumnCommandButtonType.New);

                if (lastCallbackOfNewButton != null)
                {
                    var dataSourceIndex = lastCallbackOfNewButton.VisibleIndex;

                    var dataSource = this.GetItem(dataSourceIndex);

                    if (dataSource != null)
                    {
                        var propertyNames = this.GroupFieldNames();

                        var groupPropertyValues = dataSource.FetchPropertyValues(propertyNames);

                        e.NewValues.Include(groupPropertyValues);
                    }
                }
            }

            if (this.IsFiltered())
            {
                e.NewValues.Include(FilterExpression.FetchPropertyValues());
            }
        }

        protected virtual void OnStartRowEditing_BaseImplementation(ASPxStartRowEditingEventArgs e)
        {
            if (SettingsText.StartRowEditing.CommandUpdate.IsNotEmpty())
            {
                SettingsText.CommandUpdate = SettingsText.StartRowEditing.CommandUpdate.Truncate(
                    SettingsText.StartRowEditing.CommandUpdateWidth
                );
            }

            if (SettingsText.StartRowEditing.PopupEditFormCaption.IsNotEmpty())
            {
                SettingsText.PopupEditFormCaption = SettingsText.StartRowEditing.PopupEditFormCaptionTemplate
                    .ApplyItemValues(
                        this.GetItem(e.EditingKeyValue).AssertFound()
                    )
                    .Truncate(
                        SettingsText.StartRowEditing.PopupEditFormCaptionWidth
                    );
            }
        }


        protected virtual void OnEditorInitialize_BaseImplementation(ASPxGridViewEditorEventArgs e)
        {
            if (ReadOnly)
            {
                e.Editor.ReadOnly(true);
            }
        }


        protected virtual void OnCustomErrorText_BaseImplementation(ASPxGridViewCustomErrorTextEventArgs e)
        {
        }

        
        protected virtual void OnBeforeRowInserting_BaseImplementation(ASPxDataInsertingEventArgs e)
        {
        }

        protected virtual void OnAfterRowInserting_BaseImplementation(ASPxDataInsertingEventArgs e)
        {
            if (DataSource is ISmartDataSourse)
            {
                DataSource.Dirty();

                e.Cancel = true;

                CancelEdit();
            }
        }

        protected virtual void OnBeforeRowUpdating_BaseImplementation(ASPxDataUpdatingEventArgs e)
        {
        }

        protected virtual void OnAfterRowUpdating_BaseImplementation(ASPxDataUpdatingEventArgs e)
        {
            if (DataSource is ISmartDataSourse)
            {
                DataSource.Dirty();

                e.Cancel = true;

                CancelEdit();
            }
        }

        protected virtual void OnBeforeRowDeleting_BaseImplementation(ASPxDataDeletingEventArgs e)
        {
        }

        protected virtual void OnAfterRowDeleting_BaseImplementation(ASPxDataDeletingEventArgs e)
        {
            if (DataSource is ISmartDataSourse)
            {
                DataSource.Dirty();

                e.Cancel = true;
            }
        }



        protected override IStateManager[] GetStateManagedObjects()
        {
            var result = new List<IStateManager>
            {
                ControlStyle
            };

            if (IsSettingsLoadingPanelStoreToViewState())
                result.Add(SettingsLoadingPanel);
            if (IsClientSideEventsStoreToViewState())
                result.Add(ClientSideEventsInternal);
            if (IsStylesStoreToViewState())
                result.Add(StylesInternal);
            if (IsImagesStoreToViewState())
                result.Add(ImagesInternal);

            result.AddRange(
                new List<IStateManager>
                {
                    Columns,
                    GroupSummary,
                    TotalSummary,
                    Settings,
                    SettingsPager,
                    SettingsEditing,
                    SettingsBehavior,
                    SettingsCustomizationWindowInternal,
                    SettingsCookies,
                    SettingsDetail,
                    SettingsText,
                    SettingsPopup,
                    SettingsCommandButton,
                    SettingsDataSecurity,
                    StylesEditors,
                    StylesFilterControl,
                    StylesPager,
                    StylesPopup,
                    ImagesEditors,
                    ImagesFilterControl
                });

            return result.ToArray();
        }
    }
}