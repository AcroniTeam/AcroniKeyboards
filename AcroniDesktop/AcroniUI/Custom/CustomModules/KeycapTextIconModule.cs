﻿using AcroniLibrary;
using AcroniLibrary.DesignMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcroniUI.Custom.CustomModules
{
    public partial class KeycapTextIconModule : KeycapParentModule
    {

        public KeycapTextIconModule()
        {
            InitializeComponent();
            Bunifu.Framework.UI.BunifuElipse e = new Bunifu.Framework.UI.BunifuElipse();
            e.ApplyElipse(pnlBtnIconChosen, 5);
        }

        //Declaração dos textos para aplicá-los às keycaps do teclado

        public string Uppertext { get; set; }

        public string Maintext { get; set; }

        public string Bottomtext { get; set; }

        //Declaração das propriedades dos ícones
        private Queue<Image> ImageQueue = new Queue<Image>();

        public Image SelectedIcon { get; set; }

        public static bool HasChosenAIcon { get; set; }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.FadeOut(30);
            this.Close();
        }

        private void GeneralTextChanged(object sender, EventArgs e)
        {
            TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder twp = (TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder)sender;
            twp.ForeColor = Color.FromArgb(114, 137, 218);

            if (sender == txt1)
                Uppertext = txt1.Text;
            else if (sender == txt2)
                Maintext = txt2.Text;
            else
                Bottomtext = txt3.Text;
        }

        private void btnNewIcon_Click(object sender, EventArgs e)
        {
            List<Image> insertableArray = new List<Image> { };
            using (OpenFileDialog iconGetter = new OpenFileDialog())
            {
                iconGetter.InitialDirectory = @"C:\";
                iconGetter.Title = "Qual o ícone que deseja adicionar?";
                iconGetter.Filter = "Todos os tipos de imagem | *jpg; *.jpeg; *.bmp; *.png |BMP | *.bmp | JPG | *.jpg; *.jpeg | PNG | *.png ";
                iconGetter.Multiselect = true;
                if (iconGetter.ShowDialog() == DialogResult.OK)
                {
                    foreach (String fileDirectory in iconGetter.FileNames)
                        ImageQueue.Enqueue(Image.FromFile(fileDirectory));

                    while (ImageQueue.Count > 10)
                        ImageQueue.Dequeue();
                }
                for (int aux = ImageQueue.Count - 1; aux >= 0; aux--)
                {
                    insertableArray.Add(ImageQueue.ToArray()[aux]);
                }
            }
            for (int i = 0; i < ImageQueue.Count; i++)
            {
                (pnlIcons.Controls[$"picBoxIcon{i + 1}"] as PictureBox).Image = insertableArray[i];
                (pnlIcons.Controls[$"picBoxIcon{i + 1}"] as PictureBox).Visible = true;
            }
        }

        private void picIcons_Click(object sender, EventArgs e)
        {
            PictureBox icon = (PictureBox)sender;
            icon.Tag = "Chosen";
            if (icon.Tag.Equals("Chosen"))
                icon.Focus();

            if (sender != null)
            {
                pnlBtnIconChosen.Visible = true;
                pnlBtnIconChosen.Location = new Point(icon.Location.X + icon.Size.Width - 10, icon.Location.Y + icon.Size.Height - 10);
                SelectedIcon = icon.Image;
                HasChosenAIcon = true;
            }
        }

        #region Métodos de transição de cores dos textboxes
        private void GeneralMouseMove(object sender, MouseEventArgs e)
        {
            TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder twp = (TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder)sender;
            twp.ForeColor = Color.FromArgb(114, 137, 218);

            if (sender == txt1 || sender == apnlTextbox1)
            {
                apnlTextbox1.BackColor = Color.FromArgb(42, 45, 50);
                txt1.BackColor = Color.FromArgb(42, 45, 50);
            }
            else if (sender == txt2 || sender == apnlTextbox2)
            {
                apnlTextbox2.BackColor = Color.FromArgb(42, 45, 50);
                txt2.BackColor = Color.FromArgb(42, 45, 50);
            }
            else if (sender == txt3 || sender == apnlTextbox3)
            {
                apnlTextbox3.BackColor = Color.FromArgb(42, 45, 50);
                txt3.BackColor = Color.FromArgb(42, 45, 50);
            }
            Cursor = Cursors.IBeam;
        }

        private void GeneralMouseLeave(object sender, EventArgs e)
        {
            TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder twp = (TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder)sender;
            twp.ForeColor = Color.FromArgb(114, 137, 218);

            if (sender == txt1 || sender == apnlTextbox1)
            {
                apnlTextbox1.BackColor = Color.FromArgb(38, 41, 45);
                txt1.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt2 || sender == apnlTextbox2)
            {
                apnlTextbox2.BackColor = Color.FromArgb(38, 41, 45);
                txt2.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt3 || sender == apnlTextbox3)
            {
                apnlTextbox3.BackColor = Color.FromArgb(38, 41, 45);
                txt3.BackColor = Color.FromArgb(38, 41, 45);
            }
            Cursor = Cursors.Default;
        }

        private void GeneralMouseUp(object sender, MouseEventArgs e)
        {
            TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder twp = (TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder)sender;
            twp.ForeColor = Color.FromArgb(114, 137, 218);

            if (sender == txt1 || sender == apnlTextbox1)
            {
                apnlTextbox1.BackColor = Color.FromArgb(38, 41, 45);
                txt1.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt2 || sender == apnlTextbox2)
            {
                apnlTextbox2.BackColor = Color.FromArgb(38, 41, 45);
                txt2.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt3 || sender == apnlTextbox3)
            {
                apnlTextbox3.BackColor = Color.FromArgb(38, 41, 45);
                txt3.BackColor = Color.FromArgb(38, 41, 45);
            }
            Cursor = Cursors.IBeam;
        }

        private void GeneralMouseDown(object sender, MouseEventArgs e)
        {
            TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder twp = (TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder)sender;
            twp.ForeColor = Color.FromArgb(114, 137, 218);

            if (sender == txt1 || sender == apnlTextbox1)
            {
                apnlTextbox1.BackColor = Color.FromArgb(38, 41, 45);
                txt1.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt2 || sender == apnlTextbox2)
            {
                apnlTextbox2.BackColor = Color.FromArgb(38, 41, 45);
                txt2.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt3 || sender == apnlTextbox3)
            {
                apnlTextbox3.BackColor = Color.FromArgb(38, 41, 45);
                txt3.BackColor = Color.FromArgb(38, 41, 45);
            }
            Cursor = Cursors.IBeam;
        }

        private void GeneralMouseClick(object sender, MouseEventArgs e)
        {
            TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder twp = (TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder)sender;
            twp.ForeColor = Color.FromArgb(114, 137, 218);

            if (sender == txt1 || sender == apnlTextbox1)
            {
                apnlTextbox1.BackColor = Color.FromArgb(38, 41, 45);
                txt1.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt2 || sender == apnlTextbox2)
            {
                apnlTextbox2.BackColor = Color.FromArgb(38, 41, 45);
                txt2.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt3 || sender == apnlTextbox3)
            {
                apnlTextbox3.BackColor = Color.FromArgb(38, 41, 45);
                txt3.BackColor = Color.FromArgb(38, 41, 45);
            }
            Cursor = Cursors.IBeam;
        }

        private void GeneralClick(object sender, EventArgs e)
        {
            TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder twp = (TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder)sender;
            twp.ForeColor = Color.FromArgb(114, 137, 218);

            if (sender == txt1 || sender == apnlTextbox1)
            {
                apnlTextbox1.BackColor = Color.FromArgb(38, 41, 45);
                txt1.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt2 || sender == apnlTextbox2)
            {
                apnlTextbox2.BackColor = Color.FromArgb(38, 41, 45);
                txt2.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt3 || sender == apnlTextbox3)
            {
                apnlTextbox3.BackColor = Color.FromArgb(38, 41, 45);
                txt3.BackColor = Color.FromArgb(38, 41, 45);
            }
            Cursor = Cursors.IBeam;
        }

        private void GeneralEnter(object sender, EventArgs e)
        {
            TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder twp = (TheKhanSoftsWatermarkTextbox.TextboxWithPlaceholder)sender;
            twp.ForeColor = Color.FromArgb(114, 137, 218);

            if (sender == txt1 || sender == apnlTextbox1)
            {
                apnlTextbox1.BackColor = Color.FromArgb(38, 41, 45);
                txt1.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt2 || sender == apnlTextbox2)
            {
                apnlTextbox2.BackColor = Color.FromArgb(38, 41, 45);
                txt2.BackColor = Color.FromArgb(38, 41, 45);
            }
            else if (sender == txt3 || sender == apnlTextbox3)
            {
                apnlTextbox3.BackColor = Color.FromArgb(38, 41, 45);
                txt3.BackColor = Color.FromArgb(38, 41, 45);
            }
            Cursor = Cursors.IBeam;
        }
        #endregion


    }
}
