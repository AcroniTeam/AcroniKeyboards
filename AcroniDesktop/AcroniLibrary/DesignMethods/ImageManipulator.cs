using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace AcroniLibrary.DesignMethods
{
    public class ImageManipulator
    {
        public static Image getPrintOf(Form form)
        {
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0,0,0,0, printscreen.Size);
            printscreen.Save($@"{Application.StartupPath}\printscreen.png", ImageFormat.Png);
            return printscreen;
        }
    }
}
