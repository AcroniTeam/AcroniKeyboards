﻿using AcroniLibrary.FileInfo;
using System.Collections.Generic;
using System.Drawing;

namespace AcroniLibrary.FileInfo
{
    public class Share
    {
        public static List<Image> ResourcesImage { get; set; }  = new List<Image>();

        public static User User = new User();
        public static Keyboard Keyboard { get; set; } = new Keyboard();
        public static Collection Collection { get; set; } = new Collection();
        public static int KeyboardsQuantity { get; set; } = 0;
        public static bool EditKeyboard { get; set; }
        //Deixei essa propriedade porque dava um conflito depois
        public static string KeyboardNameNotCreated { get; set; }
    }
}
