using System.Text;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView.Rendering;
using DevExpress.Web.ASPxTreeList;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings;
using WebAppCommons.Classes.Controls.ASPx.xWebControlBase;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewHtmlEditFormPopup : GridViewHtmlEditFormPopup
    {
        protected new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }

        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }


        public new ASPxSmartGridViewHtmlEditFormPopupClientSideEvents ClientSideEvents
        {
            get { return (ASPxSmartGridViewHtmlEditFormPopupClientSideEvents) base.ClientSideEvents; }
        }



        public ASPxSmartGridViewHtmlEditFormPopup(ASPxSmartGridView grid, int visibleIndex) : base(grid, visibleIndex)
        {
        }



        protected override ClientSideEventsBase CreateClientSideEvents()
        {
            return new ASPxSmartGridViewHtmlEditFormPopupClientSideEvents();
        }



        protected override string GetClientObjectClassName()
        {
            return "ASPxClientSmartPopupEditForm";
        }

        protected override void RegisterIncludeScripts()
        {
            base.RegisterIncludeScripts();

            RegisterIncludeScript(typeof(ASPxSmartGridViewHtmlEditFormPopup), "WebAppCommons.Scripts.Controls.ASPx.ASPxCollectionsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSmartGridViewHtmlEditFormPopup), "WebAppCommons.Scripts.Controls.ASPx.ASPxControlsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSmartGridViewHtmlEditFormPopup), "WebAppCommons.Scripts.Controls.ASPx.ASPxSmartKbdHelper.js");
            RegisterIncludeScript(typeof(ASPxSmartGridViewHtmlEditFormPopup), "WebAppCommons.Scripts.Controls.ASPx.ASPxSmartPopupEditForm.js");
        }

        protected override void GetCreateClientObjectScript(StringBuilder stb, string localVarName, string clientName)
        {
            base.GetCreateClientObjectScript(stb, localVarName, clientName);

            stb.AppendFormat("{0}.SetParentGridView({1});\n", localVarName, HtmlConvertor.ToJSON(Grid.ClientID()));
        }


        protected override void CreateControlHierarchy()
        {
            base.CreateControlHierarchy();

            // Если в качестве способа редактирования грида используется EditForm, при этом для EditForm задан template, то на callback, 
            // приходящий из контрола EditForm'ы, для грида создается EditForm с ID отличным от присвоенного ранее ("efnew" вместо к примеру "ef1"):
            // по всей видимости отсутсвует возможность восстановить calbackstate у грида либо вообще либо в полном объеме, 
            // что приводит к "потере" DataProxy.EditingRowVisibleIndex у самого грида - как следствие происходит "потеря" значения 
            // VisibleIndex/ItemIndex у GridViewEditFormTemplateContainer (см.метод GetID в базовой имплементации данного класса)
            //
            // Таким образом, при попытке обработать данный callback возникает исключение:
            // [The target "ctl00$MainContent$gridView$DXPEForm$ef4$TC$pcEditFormPages$DXEditor3" for the callback could not be found 
            // or did not implement ICallbackEventHandler.]"
            //
            // При создании EditForm из шаблона имеем следующую иерархию контролов:
            // [инстанция шаблона EditForm] -> GridViewEditFormTemplateContainer -> ClientIDHelper.TemplateHierarchyContainer -> [ContentDiv у GridViewHtmlEditFormPopup]
            // ИЛИ
            // [инстанция шаблона EditForm] -> GridViewEditFormTemplateContainer -> ClientIDHelper.TemplateContainerHolder -> ClientIDHelper.TemplateHierarchyContainer -> [ContentDiv у GridViewHtmlEditFormPopup]
            // Иерархия контролов зависит от ClientIDMode у TemplateHierarchyContainer. При этом значение ID из GridViewEditFormTemplateContainer.GetID() 
            // получает контрол вложенный в ClientIDHelper.TemplateHierarchyContainer:
            // * в первом случае - GridViewEditFormTemplateContainer 
            // * во втором случае - ClientIDHelper.TemplateContainerHolder
            //
            // Учитывая, что с очень большой вероятностью конкретная инстанция шаблона EditForm всегда одна и отсутвует возможность перегрузить 
            // метод AddEditFormTemplateControl у ASPxGridViewRenderHelper, то мы постараемся недопустить появления описанного исключения 
            // просто изменив ID у соответствующего контрола с "efnew"/"ef[visibleindex]" на "ef" сразу после создания
            // 
            // ВНИМАНИЕ! СТОИТ УЧИТЫВАТЬ, ЧТО СОБЫТИЯ Init У КОНТРОЛОВ ВХОДЯЩИХ В СОСТАВ TEMPLATE'А EDITFORM БУДУТ ВОЗНИКАТЬ ДО ВНЕСЕНИЯ 
            // ИЗМЕНЕНИЙ В ID СООТВЕТСТВУЮЩЕГО КОНТРОЛА

            if (Grid.Templates.EditForm != null)
            {
                var requiredControl = ContentDiv.FindControlSmart(expression: @"\Aef(\d+|new)\z");
                
                if (requiredControl != null)
                {
                    var xxx = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef0_ctl00_DXEditor4");
                    var yyy1 = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef0_ctl00_DXEditor4_1_DDD_1_TreeList_0");
                    var yy1 = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef0_ctl00_DXEditor4_2_DDD_2_TreeList_0");
                    var yyy01 = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef0_ctl00_DXEditor4_0_DDD_0_TreeList");
                    var yyy0 = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef0_ctl00_DXEditor4_0_DDD_0_TreeList_0");
                    var yyy = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef0_ctl00_DXEditor4_DDD_TreeList");

                    var control = requiredControl.SetID("ef");
                    control.ResetChildControlsHierarchy<ASPxLabel>(); // Данная манипуляция необходима по причине того, что AssociatedControlID у ASPxLabel интерпритируются некорректно - фактически с учетом "efnew"/"ef[visibleindex]". Другого способа, кроме как "адресно" произвести ResetControlHierarchy найти не получилось.
                    control.ResetChildControlsHierarchy<ASPxTreeList>(); // Данная манипуляция необходима по причине того, что AssociatedControlID у ASPxLabel интерпритируются некорректно - фактически с учетом "efnew"/"ef[visibleindex]". Другого способа, кроме как "адресно" произвести ResetControlHierarchy найти не получилось.


//                    var xxx = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef_ctl00_DXEditor4");
//                    var yyy1 = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef_ctl00_DXEditor4_1_DDD_1_TreeList_0");
//                    var yy1 = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef_ctl00_DXEditor4_2_DDD_2_TreeList_0");
//                    var yyy01 = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef_ctl00_DXEditor4_0_DDD_0_TreeList");
//                    var yyy0 = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef_ctl00_DXEditor4_0_DDD_0_TreeList_0");
//                    var yyy = requiredControl.FindControlSmart(x => x.ClientID == "ctl00_PageContent_MainGridView_DXPEForm_ef_ctl00_DXEditor4_DDD_TreeList_0");


                }
            }
        }
    }
}