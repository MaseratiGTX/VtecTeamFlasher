using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;

namespace WebAppCommons.Classes.Controls.ASPx
{
    public class ASPxSmartStaticDataViewControl : ASPxDataWebControl
    {
        protected InternalTable MainTable;
        protected IList InternalDataSource;


        [DefaultValue("")]
        public string HeaderField
        {
            get { return GetStringProperty("HeaderField", string.Empty); }
            set { SetStringProperty("HeaderField", string.Empty, value); }
        }
        
        [DefaultValue("")]
        public string ContentField
        {
            get { return GetStringProperty("ContentField", string.Empty); }
            set { SetStringProperty("ContentField", string.Empty, value); }
        }

        [Category("Client-Side")]
        [DefaultValue("")]
        [AutoFormatDisable]
        public string ClientInstanceName
        {
            get { return ClientInstanceNameInternal; }
            set { ClientInstanceNameInternal = value; }
        }

        public ASPxSmartStaticDataViewControl()
        {
        }

        public ASPxSmartStaticDataViewControl(ASPxWebControl ownerControl) : base(ownerControl)
        {
        }

        protected override string GetClientObjectClassName()
        {
            return "ASPxClientSmartStaticDataViewControl";
        }

        protected override void RegisterIncludeScripts()
        {
            base.RegisterIncludeScripts();

            RegisterIncludeScript(typeof(ASPxSmartStaticDataViewControl), "WebAppCommons.Scripts.Controls.ASPx.ASPxSmartStaticDataViewControl.js");
        }

        protected override void RegisterDefaultRenderCssFile()
        {
            base.RegisterDefaultRenderCssFile();
            ResourceManager.RegisterCssResource(Page, typeof(ASPxSmartStaticDataViewControl), "WebAppCommons.Styles.Controls.ASPx.ASPxSmartStaticDataViewControl.css");

        }


        protected override void CreateControlHierarchy()
        {
            base.CreateControlHierarchy();

            MainTable = RenderUtils.CreateTable(true);
            Controls.Add(MainTable);
        }
       
        protected override void PrepareControlHierarchy()
        {
            base.PrepareControlHierarchy();

            RenderUtils.AssignAttributes(this, MainTable);

            MainTable.CssClass = "dxssdvc";
            
            var style = GetControlStyle();
                style.AssignToControl(MainTable, AttributesRange.All);
            
            PrepareRows();
        }

        protected override void PerformDataBinding(string dataHelperName, IEnumerable data)
        {
            base.PerformDataBinding(dataHelperName, data);
            ResetControlHierarchy();
            InternalDataSource = DataUtils.ConvertEnumerableToList(data);

        }


        private void PrepareRows()
        {
            if (InternalDataSource == null) return;
            
            for (var index = 0; index < InternalDataSource.Count; index++)
            {
                var row = RenderUtils.CreateTableRow();

                CreateHeaderCell(index, row);
                CreateContentCell(index, row);

                MainTable.Rows.Add(row);
            }
        }
        
        private void CreateHeaderCell(int index, TableRow row)
        {
            var cellHeader = RenderUtils.CreateTableCell();
                cellHeader.CssClass = "caption";
                cellHeader.Controls.Add(GetBoundHeaderControl(index));
            row.Cells.Add(cellHeader);
        }

        private void CreateContentCell(int index, TableRow row)
        {
            var cellContent = RenderUtils.CreateTableCell();
                cellContent.CssClass = "control";
                cellContent.Controls.Add(GetBoundContentControl(index));
            row.Cells.Add(cellContent);
        }

        private Control GetBoundHeaderControl(int index)
        {
            var itemKey = GetFieldValue(index, HeaderField);

            var lbl = RenderUtils.CreateLabel();
                lbl.ID = "header" + index;
                lbl.Text = itemKey.ToString();
            return lbl;
        }
        
        private Control GetBoundContentControl(int index)
        {
            var itemValue = GetFieldValue(index, ContentField);

            var lbl = RenderUtils.CreateLabel();
                lbl.ID = "content" + index;
                lbl.Text = itemValue.ToString();
            return lbl;
        }

        private object GetFieldValue(int index, string fieldName)
        {
            var value = GetFieldValue(InternalDataSource[index], fieldName, true, "");
            return value ?? string.Empty;
        }
    }
}