using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering.ControlsContainers
{
    public class SimpleControlsContainer : IControlsContainer
    {
        protected List<WebControl> InternalControlsList { get; set; }
        
        protected Control ControlsContainer { get; set; }


        public WebControl Owner { get; protected set; }


        public bool IsEmpty
        {
            get { return InternalControlsList.Count == 0; }
        }

        public bool IsNotEmpty
        {
            get { return InternalControlsList.Count > 0; }
        }


        public List<WebControl> Controls
        {
            get { return InternalControlsList.ToList(); }
        }



        public SimpleControlsContainer(WebControl owner)
        {
            InternalControlsList = new List<WebControl>();
            
            Owner = owner;
            
            ControlsContainer = Owner;
        }


        
        public T Add<T>(T control) where T : WebControl
        {
            ControlsContainer.Add(control);

            InternalControlsList.Add(control);

            return control;
        }
    }
}