using AcroniLibrary.Drawing;
using AcroniLibrary.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcroniLibrary.FileInfo;
using AcroniLibrary;
using Bunifu.Framework.UI;

namespace AcroniUI
{
    public partial class MinhaConta : TemplateMenu
    {
        public MinhaConta()
        {
            InitializeComponent();

            pnlEscurecerImg.BackColor = Color.FromArgb(90, pnlEscurecerImg.BackColor);

            ChamarImagemDoBanco();

            List<object> ret = SQLProcMethods.SELECT_Info_MinhaConta();

            txtNome.Text = ret[0].ToString().Replace('-',' ');
            txtNome.HintText = ret[0].ToString().Replace('-', ' ');
            txtCPF.Text = String.IsNullOrEmpty(ret[1].ToString()) ? "NÃO TEMOS O SEU CPF. Informe-o" : ret[1].ToString();
            txtCPF.HintText = String.IsNullOrEmpty(ret[1].ToString()) ? "NÃO TEMOS O SEU CPF. Informe-o" : ret[1].ToString();
            txtCEP.Text = String.IsNullOrEmpty(ret[2].ToString()) ? "Informe o seu CEP :D" : ret[2].ToString();
            txtCEP.HintText = String.IsNullOrEmpty(ret[2].ToString()) ? "Informe o seu CEP :D" : ret[2].ToString();
            txtEmail.Text = ret[3].ToString();
            txtEmail.HintText = ret[3].ToString();
            txtUser.Text = ret[4].ToString();
            txtUser.HintText = ret[4].ToString();
            txtPass.Text = ret[5].ToString();
            txtPass.HintText = ret[5].ToString();
            nameofTextbox.Clear();
            btnSave.BackColor = Color.FromArgb(34, 36, 40);
            btnSave.Text = "Salvo";
            btnSave.Tag = "Dont handler";
            btnSave.Click -= btnSave_Click;
        }

        private void ChamarImagemDoBanco()
        {
            using (var ms = new MemoryStream(SQLProcMethods.SELECT_UserImage()))
            {
                pnlUserImg.BackgroundImage = new Bitmap(ms);
            }
        }

        SqlConnection conexao_SQL = new SqlConnection(SQLConnection.nome_conexao);
        //SqlCommand comando_SQL;

        Regex validacao_email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        private void pnlUserImg_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pnlEscurecerImg_MouseEnter(object sender, EventArgs e)
        {
            pnlEscurecerImg.BackColor = Color.FromArgb(170, pnlEscurecerImg.BackColor);
        }

        private void pnlEscurecerImg_MouseLeave(object sender, EventArgs e)
        {
            pnlEscurecerImg.BackColor = Color.FromArgb(90, pnlEscurecerImg.BackColor);
        }

        private void txtBoxMyAccount_MouseLeave(object sender, EventArgs e)
        {
            if (((BunifuMaterialTextbox)sender).ForeColor == Color.Firebrick)
            {
                ((BunifuMaterialTextbox)sender).ForeColor = Color.White;
                ((BunifuMaterialTextbox)sender).Parent.BackColor = Color.FromArgb(53, 56, 62);
            }

            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                if (!nameofTextbox.Contains(txtEmail.Name))
                    nameofTextbox.Add(txtEmail.Name);

                //if (!SQLMethods.SELECT_HASROWS("SELECT email FROM tblCliente WHERE email LIKE '" + txtEmail.Text + "'") && Regex.IsMatch(txtEmail.Text, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
                txtEmail.AccessibleDescription = "Validated";
            }
            else
            {
                nameofTextbox.Remove(txtEmail.Name);
                txtEmail.AccessibleDescription = "Not";
            }

            if (!String.IsNullOrEmpty(txtNome.Text))
            {
                if (!nameofTextbox.Contains(txtNome.Name))
                    nameofTextbox.Add(txtNome.Name);

                if (txtNome.Text.Contains(" "))
                {
                    txtNome.AccessibleDescription = "Validated";
                }
            }
            else
            {
                nameofTextbox.Remove(txtNome.Name);
                txtNome.AccessibleDescription = "Not";
            }

            if (!String.IsNullOrEmpty(txtPass.Text))
            {
                if (!nameofTextbox.Contains(txtPass.Name))
                    nameofTextbox.Add(txtPass.Name);

            }
            else
                nameofTextbox.Remove(txtPass.Name);

            if (!String.IsNullOrEmpty(txtUser.Text))
            {
                if (!nameofTextbox.Contains(txtUser.Name))
                    nameofTextbox.Add(txtUser.Name);

                //if (!SQLMethods.SELECT_HASROWS("SELECT usuario FROM tblCliente WHERE usuario LIKE '" + txtUser + "'"))
                txtUser.AccessibleDescription = "Validated";
            }
            else
            {
                nameofTextbox.Remove(txtUser.Name);
                txtUser.AccessibleDescription = "Not";
            }

            if (!String.IsNullOrEmpty(txtCPF.Text))
            {
                if (!nameofTextbox.Contains(txtCPF.Name))
                    nameofTextbox.Add(txtCPF.Name);

                if (Validator.IsCPF(txtCPF.Text))
                    txtCPF.AccessibleDescription = "Validated";
            }
            else
            {
                nameofTextbox.Remove(txtCPF.Name);
                txtCPF.AccessibleDescription = "Not";
            }

            if (!String.IsNullOrEmpty(txtCEP.Text))
            {
                if (!nameofTextbox.Contains(txtCEP.Name))
                    nameofTextbox.Add(txtCEP.Name);
            }
            else
                nameofTextbox.Remove(txtCEP.Name);

            if (nameofTextbox.Count > 0)
            {
                btnSave.BackColor = Color.FromArgb(0, 147, 255);
                btnSave.Text = "Salvar";
                if (btnSave.Tag.Equals("Dont handler"))
                    btnSave.Click += btnSave_Click;
                btnSave.Tag = "Has handler";
            }
            else
            {
                btnSave.BackColor = Color.FromArgb(34, 36, 40);
                btnSave.Text = "Salvo";
                btnSave.Tag = "Dont handler";
                btnSave.Click -= btnSave_Click;
            }
        }

        //Isso serve para eu só mandar a imagem pro banco quando ele for salvar, e não quando ele simplesmente mudar a imagem.

        private Bitmap bmp;

        private void AlterarImagem(object sender, EventArgs e)
        {
            using (OpenFileDialog profilePic = new OpenFileDialog())
            {
                profilePic.InitialDirectory = @"C:\";
                profilePic.Title = "Qual imagem será sua chamativa foto de perfil?";
                profilePic.Filter = "Todos os tipos de imagem | *jpg; *.jpeg; *.bmp; *.png; *.ico|BMP | *.bmp | JPG | *.jpg; *.jpeg | PNG | *.png | ICO | *.ico | Todos| *.*";
                profilePic.Multiselect = false;
                if (profilePic.ShowDialog() == DialogResult.OK)
                {
                    bmp = new Bitmap(Image.FromFile(profilePic.FileName));
                    pnlUserImg.BackgroundImage = bmp;
                    pnlUserImg.AccessibleDescription = "Validated";
                    nameofTextbox.Add(pnlUserImg.Name);
                    btnSave.BackColor = Color.FromArgb(0, 147, 255);
                    btnSave.Text = "Salvar";
                    if (btnSave.Tag.Equals("Dont handler"))
                        btnSave.Click += btnSave_Click;
                    btnSave.Tag = "Has handler";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (String name in nameofTextbox)
            {
                Control txtBox = (Controls.Find(name, true))[0];
                if (txtBox.AccessibleDescription.Equals("Validated"))
                {
                    if (!txtBox.Name.Equals("pnlUserImg"))
                        SQLProcMethods.UPDATE_Info_MinhaConta(txtBox.Tag.ToString(), txtBox.Text, Share.User.ID);
                    else
                    {
                        byte[] img = ImageConvert.ImageToByteArray(bmp, ImageFormat.Bmp);
                        SQLProcMethods.UPDATE_ImgCliente(img, Share.User.ID);
                    }
                }
                else
                {
                    (Controls.Find(name, true))[0].Parent.BackColor = Color.Firebrick;
                    (Controls.Find(name, true))[0].ForeColor = Color.Firebrick;
                }
            }
            btnSave.BackColor = Color.FromArgb(34, 36, 40);
            btnSave.Text = "Salvo";
            btnSave.Tag = "Dont handler";
            btnSave.Click -= btnSave_Click;
        }

        private void MinhaConta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Tag.Equals("not salvo"))
            {
                AcroniControls.AcroniMessageBoxConfirm a = new AcroniControls.AcroniMessageBoxConfirm("Você tem certeza que deseja sair sem salvar?");

                if (a.ShowDialog() == DialogResult.Yes)
                    ChamarImagemDoBanco();
                else
                {
                    MinhaConta mc = new MinhaConta();
                    mc.pnlUserImg.BackgroundImage = bmp;
                    mc.ShowDialog();
                }
            }
        }
        List<string> nameofTextbox = new List<string> { };
        //    private void btnAtualizar_Click(object sender, EventArgs e)
        //    {
        //        if (!possuiCamposVazios())
        //        {
        //            try
        //            {
        //                --Abrindo a conexão
        //                if (conexao_SQL.State != ConnectionState.Open)
        //                    conexao_SQL.Open();

        //                --Inicializando um comando SELECT para ver se aquele nome já existe
        //                String select = "SELECT senha FROM tblCliente WHERE senha IN ('" + txtSenha.Text + "')";
        //                comando_SQL = new SqlCommand(select, conexao_SQL);
        //                SqlDataReader tem_senha = comando_SQL.ExecuteReader();

        //                --Lendo a resposta
        //                tem_senha.Read();

        //                --".HasRows" é uma propriedade que mostra se teve alguma resposta
        //                if (!tem_senha.HasRows)
        //                {
        //                    --Fechando o SELECT para poder reutilizar
        //                    tem_senha.Close();
        //                    if (validacao_email.IsMatch(txtEmail.Text))
        //                    {
        //                        try
        //                        {
        //                            String select_email = "SELECT email FROM tblCliente WHERE email IN ('" + txtEmail.Text + "')";
        //                            comando_SQL = new SqlCommand(select_email, conexao_SQL);
        //                            SqlDataReader email_existente = comando_SQL.ExecuteReader();

        //                            if (email_existente.HasRows)
        //                            {
        //                                if (txtSenha.Text.Equals(txtRepetirSenha.Text))
        //                                {
        //                                    this.Hide();
        //                                    FrmConfirmarEmail frm = new FrmConfirmarEmail("não_possui", txtSenha.Text, txtEmail.Text, "senha");

        //                                    frm.ShowDialog();

        //                                    if (FrmConfirmarEmail.atualizacao_SUCCESS)
        //                                        Close();
        //                                    else
        //                                    {
        //                                        this.Show();
        //                                        txtEmail.ResetText(); txtRepetirSenha.ResetText(); txtSenha.ResetText();
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    lblAviso.Text = "As senhas não são iguais";
        //                                    lblAviso.Visible = true;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                email_existente.Close();
        //                                lblAviso.Text = "Este email não existe";
        //                                lblAviso.Visible = true;
        //                            }
        //                        }
        //                        catch (Exception)
        //                        {

        //                        }
        //                    }
        //                    else
        //                    {
        //                        lblAviso.Text = "O email não é valido";
        //                        lblAviso.Visible = true;
        //                    }
        //                }
        //                else
        //                {
        //                    tem_senha.Close();
        //                    lblAviso.Text = "Não se repete a mesma senha que esqueceu";
        //                    lblAviso.Visible = true;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //                conexao_SQL.Close();
        //            }
        //        }
        //        else
        //        {
        //            lblAviso.Text = "Existem campos vazios";
        //            lblAviso.Visible = true;
        //        }
        //    }
        //--Método que checa se o Form possui campos vazios
        private bool possuiCamposVazios()
        {
            bool b = false;
            foreach (Control controle in Controls)
            {
                if (controle is Bunifu.Framework.UI.BunifuMaterialTextbox)
                {
                    if ((controle as Bunifu.Framework.UI.BunifuMaterialTextbox).Text.Equals(String.Empty))
                    {
                        b = true;
                        break;
                    }
                }
            }
            return b;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void txtSenha_OnValueChanged(object sender, EventArgs e)
        //{
        //    txtSenha.isPassword = true;
        //}

        //private void txtRepetirSenha_OnValueChanged(object sender, EventArgs e)
        //{
        //    txtRepetirSenha.isPassword = true;
        //}
    }
}
