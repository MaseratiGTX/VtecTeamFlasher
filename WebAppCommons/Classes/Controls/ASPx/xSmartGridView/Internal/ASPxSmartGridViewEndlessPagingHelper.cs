using System;
using System.Collections.Generic;
using DevExpress.Web.ASPxGridView.Internal;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Internal
{
    public class ASPxSmartGridViewEndlessPagingHelper : GridViewEndlessPagingHelper
    {
        public new ASPxSmartGridView Grid 
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }

        public new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }

        protected new ASPxSmartGridViewHtmlStyleTable StyleTable
        {
            get { return Grid.ContainerControl.StyleTable; }
        }



        public ASPxSmartGridViewEndlessPagingHelper(ASPxSmartGridView grid) : base(grid)
        {
        }



        public new string GetEndlessPagingCallbackResult(string inlineScript)
        {
            throw new NotSupportedException();
        }

        protected internal new List<GridViewEndlessPagingCallbackInfo> GetDataTableCallbackInfoList()
        {
            throw new NotSupportedException();
        }

        protected internal new GridViewEndlessPagingCallbackInfo GetStyleTableCallbackInfo()
        {
            throw new NotSupportedException();
        }
    }
}