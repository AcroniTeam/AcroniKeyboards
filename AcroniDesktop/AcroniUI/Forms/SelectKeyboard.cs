using AcroniUI.Custom;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcroniUI
{
    public partial class SelectKeyboard : TemplateMenu
    {

        public SelectKeyboard()
        {
            InitializeComponent();
            Bunifu.Framework.UI.BunifuElipse roundCorners = new Bunifu.Framework.UI.BunifuElipse();
            roundCorners.ApplyElipse(lblFullSize, 20);
            roundCorners.ApplyElipse(lblTenkeyless, 20);
            roundCorners.ApplyElipse(lblCompacto, 20);

        }

        private async void btnOpenFullSize_MouseEnter(object sender, EventArgs e)
        {
            int height = 240;
            int contSize;
            int contLocation;
            if ((sender as Control) is PictureBox)
            {
                if ((sender as Control).Name.Contains("Tenkeyless"))
                {
                    contLocation = 2;
                    contSize = 4;
                }
                else if ((sender as Control).Name.Contains("Compacto"))
                {
                    contLocation = 1;
                    contSize = 2;
                }
                else
                {
                    height = 340;
                    contSize = 10;
                    contLocation = 5;
                }

                while ((sender as Control).Height < height)
                {
                    await Task.Delay(1);
                    (sender as Control).Size = new System.Drawing.Size((sender as Control).Size.Width + contSize, (sender as Control).Height + contSize);
                    (sender as Control).Location = new System.Drawing.Point((sender as Control).Location.X - contLocation, (sender as Control).Location.Y - contLocation);
                }
            }
        }

        private void picBoxOpenFullSize_Click(object sender, EventArgs e)
        {
            Fullsize fullsize = new Fullsize();
            fullsize.Show();
            this.Close();
        }

        private void picBoxOpenFullSize_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureBox).Location = new System.Drawing.Point(151, 11);
            (sender as PictureBox).Size = new System.Drawing.Size(651, 201);

            //int contSize;
            //int contLocation;
            //if ((sender as Control) is PictureBox)
            //{
            //    if ((sender as Control).Name.Contains("Tenkeyless") || (sender as Control).Name.Contains("Compacto"))
            //    {
            //        contLocation = 5;
            //        contSize = 10;
            //    }
            //    else
            //    {
            //        contSize = 20;
            //        contLocation = 10;
            //    }
            //    if ((sender as Control).Height > 202)
            //    {
            //        while ((sender as Control).Height > 201)
            //        {
            //            await Task.Delay(1);
            //            (sender as Control).Size = new System.Drawing.Size((sender as Control).Size.Width - contSize, (sender as Control).Height - contSize);
            //            (sender as Control).Location = new System.Drawing.Point((sender as Control).Location.X + contLocation, (sender as Control).Location.Y + contLocation);
            //        }
            //    }
            //}
        }

        private void picBoxCompacto_Click(object sender, EventArgs e)
        {
            Compacto compacto = new Compacto();
            compacto.Show();
            this.Close();
        }
    }
}
