using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using AcroniLibrary.DesignMethods;
using AcroniControls;

namespace AcroniUI
{
    public partial class Template : Form
    {
        public Template()
        {
            InitializeComponent();
            #region Atribuição de Dragging aos controles e no próprio form 

            ///<summary> 
            /// Esses métodos não foram gerados automaticamente. Trata-se duma maneira de permitir que não apenas o formulário seja arrastável, mas os controles também. 
            ///</summary>
            ///
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(FormDrag.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(FormDrag.Form_MouseMove);

            #endregion
        }

        #region Ações dos botões do pnlSuperior

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FadeOut();
        }

        private void lblMenus_MouseOver(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(158, 158, 158);
            ((Label)sender).Tag = "selected";
        }

        private void lblMenus_MouseLeave(object sender, EventArgs e)
        {
            //if (!((Label)sender).Tag.Equals("selected")) {
            ((Label)sender).ForeColor = Color.White;
            ((Label)sender).BackColor = Color.FromArgb(40, 42, 47);
            //}
        }
        #endregion

        private void pnlSuperior_Paint(object sender, PaintEventArgs e)
        {
            Rectangle areaBorda = pnlSuperior.ClientRectangle;
            Rectangle formBorda = this.ClientRectangle;
            areaBorda.Width--;
            areaBorda.Height--;
            formBorda.Width--;
            formBorda.Height--;
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(38, 39, 41)), 3), areaBorda);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(38, 39, 41)), 3), formBorda);
        }

        #region Sair e minimizar
        protected virtual void btnClose_Click(object sender, EventArgs e)
        {
            AcroniMessageBoxConfirm ambc = new AcroniMessageBoxConfirm("Você está saindo...", "Tem certeza disso?");
            ambc.ShowDialog();
            if (ambc.DialogResult == DialogResult.Yes)
            {
                FadeOut();
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        #endregion

        #region Timers
        private void timerFade_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0.0)
            {
                Opacity -= 0.1;
            }
            else
            {
                timerFade.Stop();
                Application.Exit();
            }
        }
        #endregion


        #region FadeIn e FadeOut
        public async void FadeOut()
        {
            while (Opacity > 0)
            {
                await Task.Delay(1);
                Opacity -= 0.05;
            }
            Application.Exit();
        }

        public async void FadeIn()
        {
            while (Opacity < 1)
            {
                await Task.Delay(1);
                Opacity += 0.05;
            }
            Opacity = 1.0;
        }
        #endregion

        private void Template_Load(object sender, EventArgs e) => FadeIn();

        private void lblArquivo_Click(object sender, EventArgs e)
        {
            if (pnlArquivos.Visible == false)
            {
                foreach (Control c in pnlArquivos.Controls)
                {
                    c.Text = "       " + c.Text;
                    c.Size = new Size(pnlArquivos.Size.Width, (pnlArquivos.Size.Height) / 4);
                }
                pnlArquivos.Location = new Point(lblArquivo.Location.X, pnlSuperior.Location.Y + 40);
                pnlArquivos.Visible = true;
            }
            else
                pnlArquivos.Visible = false;
            pnlArquivos.BringToFront();
        }

        protected void generalClickCancel(object sender, EventArgs e)
        {
            pnlArquivos.Visible = false;
        }

        private void scroll_move(object sender, MouseEventArgs e)
        {
            Label itemMenuStrip = (Label)sender;
            itemMenuStrip.BackColor = Color.FromArgb(158, 158, 158);
        }

        private void scroll_leave(object sender, EventArgs e)
        {
            Label itemMenuStrip = (Label)sender;
            itemMenuStrip.BackColor = Color.FromArgb(40, 42, 47);
        }

        protected virtual void lblSalvar_Click(object sender, EventArgs e)
        {

        }


        protected virtual void lblNovo_Click(object sender, EventArgs e)
        {
            AcroniMessageBoxConfirm mbc = new AcroniMessageBoxConfirm("Deseja salvar esse arquivo?");
            if (mbc.ShowDialog() == DialogResult.OK)
                lblSalvar_Click(sender, e);
        }

        protected virtual void lblSalvarComo_Click(object sender, EventArgs e)
        {

        }

        protected virtual void lblAbrir_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnClose.Location = new Point(1181, 0);
                btnMax.Location = new Point(1139, 0);
                btnMinimize.Location = new Point(1097, 0);
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                btnClose.Location = new Point(this.Width - 33 - btnClose.Size.Width, 0);
                btnMax.Location = new Point(this.Width - 33 - btnClose.Size.Width - btnMax.Width, 0);
                btnMinimize.Location = new Point(this.Width - 33 - btnClose.Size.Width - btnMax.Width - btnMinimize.Width, 0);
            }
        }
    }
}
