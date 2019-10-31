using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcroniLibrary;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Text;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using AcroniControls;
using AcroniLibrary.SQL;
using AcroniLibrary.FileInfo;

namespace AcroniUI
{
    public partial class TemplateMenu : Template
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(TemplateMenu));
        public TemplateMenu()
        {
            InitializeComponent();

            UpdateKeyboardQuantity();
            Bunifu.Framework.UI.BunifuElipse ellipse = new Bunifu.Framework.UI.BunifuElipse();
            foreach (Control c in pnlOptions.Controls)
            {
                ellipse.ApplyElipse(c, 7);
            }
            ImgUsu.SizeMode = PictureBoxSizeMode.Zoom;
            trocar_nome_usuario($"{SQLConnection.nome_usuario}");

            if (isLoaded)
                trocar_imagem_usuario(cliente);
            else
                trocar_imagem_usuario(selecionar_imagem_cliente());
            isLoaded = true;

        }
        static bool isLoaded = false;
        static Image cliente;

        #region Obter informações do cliente pelo banco
        public void trocar_nome_usuario(String usuario) => lblNomeUsu.Text = SQLConnection.nome_usuario;

        public void trocar_imagem_usuario(Image imagem) => ImgUsu.BackgroundImage = imagem;
        //SqlConnection conexão_SQL = new SqlConnection(SQLConnection.nome_conexao);

        public void UpdateKeyboardQuantity()
        {
            int i = 0;
            if (!(Share.User == null))
                if (Share.User.isPremiumAccount)
                {
                    lblPlanoUsu.Text = "Plano Premium";
                    lblQtdDisponivel.Visible = false;
                    lblQtdGasta.Visible = false;
                    foreach (Control c in espacoArmazenamento.Controls)
                        c.Visible = true;
                }
                else
                {
                    Share.User.KeyboardQuantity = 0;
                    foreach (Collection col in Share.User.UserCollections)
                        foreach (Keyboard k in col.Keyboards)
                            Share.User.KeyboardQuantity++;
                    lblQtdGasta.Text = "" + Share.User.KeyboardQuantity;
                    foreach (Control c in espacoArmazenamento.Controls)
                    {
                        if (i < Share.User.KeyboardQuantity)
                            c.Visible = true;
                        i++;
                    }
                    //Aqui se insere SqlProcMethods.UPDATE_QtdeTeclados();
                }
        }

        public Image selecionar_imagem_cliente()
        {
            try
            {
                byte[] img = SQLProcMethods.SELECT_UserImage();

                Image imagem_retorno = (Image)resources.GetObject("ImgUsu.Image");
                if (img != null)
                {
                    MemoryStream leitor_memoria = new MemoryStream(img);
                    imagem_retorno = Image.FromStream(leitor_memoria);
                }
                cliente = imagem_retorno;
                return imagem_retorno;
            }
            catch (Exception)
            {
                return (Image)resources.GetObject("ImgUsu.Image");
            }
        }


        #endregion
        private void CursorHand(object sender, EventArgs e)
        {
            Control Hand = (Control)sender;
            Hand.Cursor = Cursors.Hand;
        }
        private void ImgUsu_Paint(object sender, PaintEventArgs e)
        {
            using (GraphicsPath ellipse = new GraphicsPath())
            {
                Rectangle imgUsu = ImgUsu.ClientRectangle;
                ellipse.AddEllipse(0, 0, imgUsu.Width, imgUsu.Height);
                ImgUsu.Region = new Region(ellipse);
            }
            using (GraphicsPath ellipse = new GraphicsPath())
            {
                Rectangle btnConfig = this.btnConfig.ClientRectangle;

                ellipse.AddEllipse(0, 0, btnConfig.Width, btnConfig.Height);

                this.btnConfig.Region = new Region(ellipse);
            }
        }
        protected void ChangeClientImage(Bitmap bmp)
        {
            ImgUsu.BackgroundImage = bmp;
        }

        protected virtual void btnAbrirGaleria_Click(object sender, EventArgs e)
        {
            Galeria galeria = new Galeria(false);
            galeria.Show();
            this.Close();

        }

        protected virtual void btnSelectKeyboard_Click(object sender, EventArgs e)
        {
            SelectKeyboard k = new SelectKeyboard();
            k.ShowDialog();
            this.Close();
        }

        protected virtual void btnDesconectar_Click(object sender, EventArgs e)
        {
            AcroniMessageBoxConfirm confirmExit = new AcroniControls.AcroniMessageBoxConfirm("Saindo daqui", "Deseja realmente deslogar?", "OK");

            if (confirmExit.ShowDialog() == DialogResult.Yes)
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is AcroniUI.LoginAndSignUp.FrmLogin)
                    {
                        (form as LoginAndSignUp.FrmLogin).CleanAllTextbox();
                        form.Show();
                        File.Delete($@"{Application.StartupPath}\Users\{SQLConnection.nome_usuario}.acr");
                        break;
                    }
                    else
                    {
                        LoginAndSignUp.FrmLogin login = new LoginAndSignUp.FrmLogin();
                        login.CleanAllTextbox();
                        login.Show();
                    }
                }
                this.Close();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.Close();
            (new MinhaConta()).Show();
        }

        private void btnEditarMinhaConta_Click(object sender, EventArgs e)
        {
            this.Close();
            (new MinhaConta()).Show();
        }
    }
}