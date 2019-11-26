using System.Collections.Generic;
using System.Drawing;

namespace AcroniLibrary.CustomizingMethods
{
    public class IconsQueue
    {
        public static Queue<Image> Images = new Queue<Image>();
        public static void AttPanel(Image icon)
        {
            if (Images.Count > 3)
                Images.Dequeue();
            Images.Enqueue(icon);
        }
    }
}
