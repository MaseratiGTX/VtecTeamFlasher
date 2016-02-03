using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering.ControlsContainers
{
    public interface IControlsContainer
    {
        WebControl Owner { get; }

        
        bool IsEmpty { get; }
        
        bool IsNotEmpty { get; }

        
        List<WebControl> Controls { get; }


        T Add<T>(T control) where T : WebControl;
    }
}