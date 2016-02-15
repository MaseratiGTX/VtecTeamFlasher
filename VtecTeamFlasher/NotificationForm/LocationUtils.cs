using System.Drawing;
using System.Windows.Forms;

namespace VtecTeamFlasher.NotificationForm
{
    public class LocationUtils
    {
        public static Point GetCenterOf(Control control)
        {
            return new Point(control.Location.X + control.Size.Width / 2, control.Location.Y + control.Size.Height / 2);
        }

        public static Point GetLocationToCenterControl(Control controlToCenter, Control controlByWhomCenter)
        {
            Point center = GetCenterOf(controlByWhomCenter);
            return new Point(center.X - controlToCenter.Size.Width / 2, center.Y - controlToCenter.Size.Height / 2);
        }
    }
}