using System;
using System.Windows.Forms;

namespace AcroniControls
{
    public partial class MessageBoxSemInternet : Form
    {
        public MessageBoxSemInternet()
        {
            InitializeComponent();
            Bunifu.Framework.UI.BunifuElipse ellipse = new Bunifu.Framework.UI.BunifuElipse();
            ellipse.ApplyElipse(this, 15);
            btnEntendi.Click += btnEntendi_Click;
        }

        private void btnEntendi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblEntendi_Click(object sender, EventArgs e)
        {
            btnEntendi_Click(sender, e);
        }
    }
}
