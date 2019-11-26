using System;
using System.Drawing;
using System.Windows.Forms;

namespace AcroniControls
{
    public partial class AcroniMessageBoxConfirm : Form
    {
        Bunifu.Framework.UI.BunifuElipse ellipse = new Bunifu.Framework.UI.BunifuElipse();

        public AcroniMessageBoxConfirm(string message)
        {
            InitializeComponent();
            ellipse.ApplyElipse(this, 15);
            ellipse.ApplyElipse(btnNo, 5);
            ellipse.ApplyElipse(btnYes, 5);
            btnNo.Cursor = Cursors.Hand;
            btnYes.Cursor = Cursors.Hand;
            alblMessage1.Text = message;
            alblMessage2.Text = "";
        }

        public AcroniMessageBoxConfirm(string message, string message2)
        {
            InitializeComponent();
            ellipse.ApplyElipse(this, 15);
            ellipse.ApplyElipse(btnNo, 5);
            ellipse.ApplyElipse(btnYes, 5);
            btnNo.Cursor = Cursors.Hand;
            btnYes.Cursor = Cursors.Hand;
            alblMessage1.Text = message;
            alblMessage2.Text = message2;
        }

        public AcroniMessageBoxConfirm(string message, string message2, string buttonAcceptMessage)
        {
            InitializeComponent();
            ellipse.ApplyElipse(this, 15);
            ellipse.ApplyElipse(btnNo, 5);
            ellipse.ApplyElipse(btnYes, 5);
            btnNo.Cursor = Cursors.Hand;
            btnYes.Cursor = Cursors.Hand;
            alblMessage1.Text = message;
            alblMessage2.Text = message2;
            btnYes.Text = buttonAcceptMessage;
        }

        public AcceptButtons ButtonClicked { get; set; }

        private void btnCancela_MouseMove(object sender, MouseEventArgs e)
        {
            btnNo.Font = new Font("Open Sans", 12.5F, FontStyle.Underline);
        }

        private void btnCancela_MouseLeave(object sender, EventArgs e)
        {
            btnNo.Font = new Font("Open Sans", 12.5F, FontStyle.Regular);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ButtonClicked = AcceptButtons.OK;
            this.Close();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            ButtonClicked = AcceptButtons.CANCEL;
            this.Close();
        }

        private void btnOk_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackgroundImage = global::AcroniControls.Properties.Resources.fundobotaoclaro;
        }

        private void btnOk_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackgroundImage = global::AcroniControls.Properties.Resources.fundo_botao;
        }
    }
    public enum AcceptButtons
    {
        OK = 1,
        CANCEL = 2
    }
}
