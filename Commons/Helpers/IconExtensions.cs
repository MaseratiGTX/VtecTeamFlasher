using System.Drawing;

namespace Commons.Helpers
{
    public static class IconExtensions
    {
        public static Bitmap GetImage(this Icon source)
        {
            return source != null ? source.ToBitmap() : null;
        }
    }
}