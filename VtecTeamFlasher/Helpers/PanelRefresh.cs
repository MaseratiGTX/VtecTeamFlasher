using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientAndServerCommons.DataClasses;

namespace VtecTeamFlasher.Helpers
{
    public static class PanelRefresh
    {
        public static Dictionary<Control, bool> StartRefresh(Control panel, PictureBox imageControl)
        {
            var res = new Dictionary<Control, bool>();
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl != imageControl)
                {
                    res.Add(ctrl, ctrl.Enabled);
                    ctrl.Enabled = false;
                }
            }

            imageControl.Visible = true;
            imageControl.Image = Properties.Resources.Animation;

            return res;
        }

        public static void StopRefresh(Dictionary<Control, bool> controls)
        {
            foreach (var pair in controls)
            {
                pair.Key.Enabled = pair.Value;
            }
        }
    }
}
