using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxTreeList;

namespace WebAppCommons.Classes.Controls.ASPx.xTreeList
{
    public class ASPxSmartTreeList: ASPxTreeList
    {
        public override string ClientID
        {
            get
            {
                return MvcUtils.RenderMode == MvcRenderMode.RenderWithSimpleIDs ? ID : ClientIDHelper.GenerateClientID(this, base.ClientID);
            }
        }
    }
}
