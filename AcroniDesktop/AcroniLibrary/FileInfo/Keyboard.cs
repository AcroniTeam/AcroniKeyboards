using System;
using System.Collections.Generic;
using System.Drawing;

namespace AcroniLibrary.FileInfo
{
    [Serializable]
    public class Keyboard
    {
        public List<short> kbtnListSwitch { get; set; } = new List<short>();
        public List<string> kbtnListIcons { get; set; } = new List<string>();
        public List<string> kbtnList { get; set; } = new List<string>();
        public int fixedPrice { get; set; }
        public double Price { get; set; }
        public object BackgroundModeSize { get; set; }
        public List<Keycap> Keycaps { get; set; } = new List<Keycap>();
        public string Name { get; set; }
        public string ID { get; set; }
        public Image BackgroundImage { get; set; }
        public bool HasRestPads { get; set; }
        public string NickName { get; set; }
        public string KeyboardType { get; set; }
        public Image KeyboardImage { get; set; }
        public Color BackgroundColor { get; set; }
    }
}
