﻿using System;
using System.Drawing;

namespace AcroniLibrary.FileInfo
{
    [Serializable]
    public class Keycap
    {
        public string ID { get; set; }
        public Color Color { get; set; }
        public short Switch { get; set; }
        public string Text { get; set; }
        public Image Icon { get; set; }
        public Font Font { get; set; }
        public Color ForeColor { get; set; }
        public object ContentAlignment { get; set; }
        public Point TextLocation { get; set; }
    }
}
