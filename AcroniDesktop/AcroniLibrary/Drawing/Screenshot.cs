using System.Drawing;
using System.Windows.Forms;

namespace AcroniLibrary.Drawing
{
    public class Screenshot
    {
        public static Bitmap TakeSnapshot(Control ctl,Control ctl2)
        {
            Bitmap bmp = new Bitmap(ctl2.Size.Width, ctl2.Size.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(ctl2.PointToScreen(ctl.ClientRectangle.Location), new Point(-70, -70), ctl2.ClientRectangle.Size);
            return bmp;
        }
    }
}
