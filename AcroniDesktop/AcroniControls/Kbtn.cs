using System;
using System.Drawing;
using System.Windows.Forms;

namespace AcroniControls
{
    public partial class Kbtn : Button
    {
        public Kbtn()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
        }
//Não apagar, pois ele dá override para o button não mudar a cor no hover.
        protected override void OnMouseEnter(EventArgs e)
        {

        }
        /// <summary>
        /// <para>Método que muda a cor de um botão.</para>
        /// </summary>
        /// <param name="color"></param>

        public Color SetColor(Color color)
        {
            if (this.BackColor == color)
                return Color.FromArgb(26, 26, 26);
            else
                return color;
        }
    }
}
