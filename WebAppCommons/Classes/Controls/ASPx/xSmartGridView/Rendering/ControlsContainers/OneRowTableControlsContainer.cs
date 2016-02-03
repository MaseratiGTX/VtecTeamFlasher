using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering.ControlsContainers
{
    public class OneRowTableControlsContainer : IControlsContainer
    {
        protected List<WebControl> InternalControlsList { get; set; }

        protected InternalTable ControlsContainer { get; set; }
        protected TableRow MainRow { get; set; }


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



        public OneRowTableControlsContainer(WebControl owner)
        {
            InternalControlsList = new List<WebControl>();

            Owner = owner;

            Owner.Add(
                ControlsContainer = RenderUtils.CreateTable().Add(
                    MainRow = RenderUtils.CreateTableRow()
                )
            );
        }



        public T Add<T>(T control) where T : WebControl
        {
            MainRow.Add(
                RenderUtils.CreateTableCell().Add(
                    control
                )
            );

            InternalControlsList.Add(control);

            return control;
        }
    }
}