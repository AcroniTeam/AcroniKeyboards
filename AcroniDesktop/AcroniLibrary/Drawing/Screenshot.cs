using System.Drawing;
using System.Windows.Forms;

namespace AcroniLibrary.Drawing
{
    public class Screenshot
    {
        public static Bitmap TakeSnapshot(Control ctl2)
        {
            Bitmap bmp = new Bitmap(ctl2.Size.Width, ctl2.Size.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, ctl2.ClientRectangle.Size);
                return bmp;
            }

        }
    }
}
