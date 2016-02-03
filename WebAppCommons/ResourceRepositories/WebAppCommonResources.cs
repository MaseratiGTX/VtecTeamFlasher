using System.Web.UI;
using DevExpress.Web.ASPxClasses;
using WebAppCommons.Classes.Resources.ResourceHelpers;

[assembly: WebResourceAssembly(100)]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxClientUtils.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxFunctionsInfrastructure.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxControlsInfrastructure.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxCollectionsInfrastructure.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxSmartKbdHelper.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxWindowHelper.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxExpandablePanel.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxSearchPanel.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxSmartGridView.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxSmartPopupEditForm.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxSmartListBox.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxSmartPageControl.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxSmartStaticDataViewControl.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Controls.ASPx.ASPxSmartPopupControl.js", "text/javascript")]

[assembly: WebResource("WebAppCommons.Styles.Controls.ASPx.ASPxExpandablePanel.css", "text/css")]
[assembly: WebResource("WebAppCommons.Styles.Controls.ASPx.ASPxSearchPanel.css", "text/css")]
[assembly: WebResource("WebAppCommons.Styles.Controls.ASPx.ASPxSmartGridView.css", "text/css")]
[assembly: WebResource("WebAppCommons.Styles.Controls.ASPx.ASPxSmartDataView.css", "text/css")]
[assembly: WebResource("WebAppCommons.Styles.Controls.ASPx.ASPxSimpleDataViewItem.css", "text/css")]
[assembly: WebResource("WebAppCommons.Styles.Controls.ASPx.ASPxSmartStaticDataViewControl.css", "text/css")]


[assembly: WebResource("WebAppCommons.Scripts.aspx-extensions.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.webapp-commons.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Externals.jquery-1.10.2.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Externals.jquery.mb.browser.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Externals.jquery.doublescroll.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Externals.jquery.nicescroll.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Externals.jquery.xmlformat.js", "text/javascript")]
[assembly: WebResource("WebAppCommons.Scripts.Externals.jquery-extensions.js", "text/javascript")]

namespace WebAppCommons.ResourceRepositories
{
    public static class WebAppCommonResources
    {
        public static string ProvideURLFor(string resourceName)
        {
            return ResourceHelper.GetWebResourceUrl(typeof(WebAppCommonResources), resourceName.TryToFix("WebAppCommons"));
        }
    }
}