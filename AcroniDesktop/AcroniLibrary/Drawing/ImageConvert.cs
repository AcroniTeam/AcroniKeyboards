using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AcroniLibrary.Drawing
{
    public class ImageConvert
    {
        public static byte[] ImageToByteArray(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }
    }
}
