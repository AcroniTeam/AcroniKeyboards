using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AcroniControls
{
    public partial class SelectColor : Form
    {
        Button selected;
        public Color SettedColor;
        List<int> rgb = new List<int>();
        int contRGB = 0;
        public string CollectionName;
        public SelectColor(string collectionName,bool collection = true)
        {          
            InitializeComponent();
            CollectionName = collectionName;
            txtCollectionName.Text = collectionName;
            if (!collection)
            {
                label4.Visible = false;
                txtCollectionName.Visible = false;
                label4.Enabled = false;
                txtCollectionName.Enabled = false;
            }
        }

        private void changeColor_Click(object sender, EventArgs e)
        {
            if (selected != null)
                selected.FlatAppearance.BorderSize = 0;
            selected = (Button)sender;
            SettedColor = (sender as Button).BackColor;
            (sender as Button).FlatAppearance.BorderSize = 1;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            if (txtColor.Text.Length >= 4)
            {
                try
                {
                    SettedColor = ColorTranslator.FromHtml(txtColor.Text);
                }
                catch (Exception)
                {
                    try
                    {
                        foreach (char c in txtColor.Text)
                        {
                            if (c != ';'&&c!=',')
                                rgb[contRGB] += c;
                            else
                                contRGB++;
                        }
                        SettedColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                    }
                    catch (Exception) { }
                }
            }
        }

        private void SelectColor_FormClosing(object sender, FormClosingEventArgs e)
        {
            CollectionName = txtCollectionName.Text;
        }
    }
}
