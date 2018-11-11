﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using AcroniLibrary;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using AcroniLibrary.SQL;
using AcroniLibrary.FileInfo;
using AcroniLibrary.DesignMethods;

namespace AcroniUI.LoginAndSignUp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        #region Ações dos botões do menuStrip

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FadeOut();
        }

        #endregion

        #region Métodos para transição de cores dos botões do menu

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(244, 134, 134);
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(238, 63, 63);
        }

        #endregion

        #region Objetos do banco
        //Usuário para lançar o script do banco: (Usuário: Acroni, Senha: acroni7)
        SqlConnection conexão_SQL = new SqlConnection(SQLConnection.nome_conexao);
        SqlCommand comando_SQL;
        #endregion

        #region Methods of Design
        static Form layerFadeForm = new Form();

        private Form GetLayerForm()
        {
            layerFadeForm.Name = "LayerFadeForm";
            layerFadeForm.Dock = DockStyle.Fill;
            layerFadeForm.Size = new Size(1280, 720);
            layerFadeForm.FormBorderStyle = FormBorderStyle.None;
            layerFadeForm.Opacity = 0;
            layerFadeForm.BackColor = Color.FromArgb(44, 47, 55);
            layerFadeForm.Tag = "hidden";
            layerFadeForm.Show();
            layerFadeForm.Location = new Point(this.Location.X, this.Location.Y);
            return layerFadeForm;
        }

        private void ChangeReferencesOnError(ref Label label, Color backColor, ref Panel panel, ref Bunifu.Framework.UI.BunifuMaterialTextbox bunifuMaterialTextbox, String Errorlabel)
        {
            label.Text = Errorlabel;
            label.ForeColor = backColor;
            panel.CreateGraphics().DrawRectangle(new Pen(backColor, 3), 0, 0, panel.Width - 1, panel.Height - 1);
            //panel.BackColor = Color.Firebrick;
            bunifuMaterialTextbox.BackColor = Color.FromArgb(44, 47, 55);
        }

        private bool hasEmptyRegisters()
        {
            bool returnMethod = false; String controlName; //Para pegar o nome do atributo errado e dar focus nele
            foreach (Control control in pnlCadastro.Controls)
            {
                if (control is Panel)
                {
                    if (String.IsNullOrEmpty(control.GetNextControl(new Label(), true).Text))
                    {
                        returnMethod = true;
                        controlName = control.GetNextControl(new Label(), true).Name;
                        break;
                    }
                }
            }
            return returnMethod;
        }
        #endregion

        #region Timers

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void TimerFade_Tick(object sender, EventArgs e)
        {
            if (layerFadeForm.Tag.Equals("hidden"))
            {
                layerFadeForm.Opacity += 0.1;
                if (layerFadeForm.Opacity == 0.7)
                {
                    TimerFade.Stop();
                    layerFadeForm.Tag = "open";
                }
            }
            else if (layerFadeForm.Tag.Equals("open"))
            {
                layerFadeForm.Opacity -= 0.1;
                if (layerFadeForm.Opacity == 0)
                {
                    TimerFade.Stop();
                    layerFadeForm.Tag.Equals("hidden");
                }
            }
        }
        #endregion

        SelectKeyboard selecionarTeclado;

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //--Abrindo a conexão
                if (conexão_SQL.State != ConnectionState.Open)
                    conexão_SQL.Open();

                //--Criando um comando SELECT e chamando sua resposta
                String select_usuario = "SELECT usuario FROM tblCliente WHERE usuario='" + txtEntrar.Text + "'";
                comando_SQL = new SqlCommand(select_usuario, conexão_SQL);
                SqlDataReader resposta_usuario = comando_SQL.ExecuteReader();

                //--Checando se houve algum valor que retornou
                if (resposta_usuario.HasRows)
                {
                    resposta_usuario.Close();
                    try
                    {
                        //--Abrindo a conexão
                        if (conexão_SQL.State != ConnectionState.Open)
                            conexão_SQL.Open();

                        //--Criando um comando SELECT e chamando sua resposta
                        String select = "SELECT senha, tipoConta, quantidade_teclados FROM tblCliente WHERE usuario='" + txtEntrar.Text + "'";
                        comando_SQL = new SqlCommand(select, conexão_SQL);
                        SqlDataReader resposta = comando_SQL.ExecuteReader();

                        //--Checando se houve algum valor que retornou
                        if (resposta.HasRows)
                        {
                            //--Lendo a resposta
                            resposta.Read();

                            //Para pegar os valores, trate a resposta como uma Array
                            if (resposta[0].ToString().Equals(txtSenha.Text))
                            {
                                SQLConnection.nome_usuario = txtEntrar.Text;
                                Share.User = new User();
                                Share.User.KeyboardQuantity = (int)resposta[2];
                                if (File.Exists($@"{Application.StartupPath}\..\..\{txtEntrar.Text}.acr"))
                                    using (FileStream openarchive = new FileStream($@"{Application.StartupPath}\..\..\{txtEntrar.Text}.acr", FileMode.Open))
                                    {
                                        BinaryFormatter toObject = new BinaryFormatter();
                                        Share.User = (User)toObject.Deserialize(openarchive);
                                    }
                                else
                                    MetodoParaCriarPerfilADM();
                                if (resposta[1].ToString() == "p")
                                    Share.User.isPremiumAccount = true;
                                selecionarTeclado = new SelectKeyboard();
                                selecionarTeclado.Show();
                                Hide();
                            }
                            else
                            {
                                pnlQueDesce.Location = new Point(47, 444);
                                lblAviso.Text = "A senha está incorreta.";
                                lblAviso.Visible = true;
                                resposta.Close();
                            }
                        }
                        else
                        {
                            pnlQueDesce.Location = new Point(47, 444);
                            lblAviso.Text = "A senha está incorreta.";
                            lblAviso.Visible = true;
                            resposta.Close();
                        }

                        //--Fechando a conexão
                        conexão_SQL.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        conexão_SQL.Close();
                    }
                }
                else
                {
                    pnlQueDesce.Location = new Point(47, 444);
                    lblAviso.Text = "Este usuário não existe.";
                    lblAviso.Visible = true;
                    resposta_usuario.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexão_SQL.Close();
            }
        }

        private void lblCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void lnklblEsqueceuSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pnlCadastro.Tag.Equals("Closed"))
                TimerSlide.Start();
            AcceptButton = btnCadastrar;
        }

        private void pnlVisibiladade_Click(object sender, EventArgs e)
        {
            if (((Panel)sender).Equals(pnlVisibiladade))
            {
                if (pnlVisibiladade.Tag.Equals("false"))
                {
                    pnlVisibiladade.BackgroundImage = new Bitmap(AcroniUI.Properties.Resources.olho);
                    txtSenha.isPassword = false;
                    pnlVisibiladade.Tag = "true";
                }
                else
                {
                    pnlVisibiladade.BackgroundImage = new Bitmap(AcroniUI.Properties.Resources.olhoblock);
                    txtSenha.isPassword = true;
                    pnlVisibiladade.Tag = "false";
                }
            }
            else if (((Panel)sender).Equals(pnlVisibilidadeCadSenha))
            {
                if (pnlVisibilidadeCadSenha.Tag.Equals("false"))
                {
                    pnlVisibilidadeCadSenha.BackgroundImage = new Bitmap(AcroniUI.Properties.Resources.olho);
                    txtCadPass.isPassword = false;
                    pnlVisibilidadeCadSenha.Tag = "true";
                }
                else
                {
                    pnlVisibilidadeCadSenha.BackgroundImage = new Bitmap(AcroniUI.Properties.Resources.olhoblock);
                    txtCadPass.isPassword = true;
                    pnlVisibilidadeCadSenha.Tag = "false";
                }
            }
            else
            {
                if (pnlVisibiladadeRepSenha.Tag.Equals("false"))
                {
                    pnlVisibiladadeRepSenha.BackgroundImage = new Bitmap(AcroniUI.Properties.Resources.olho);
                    txtCadRepPass.isPassword = false;
                    pnlVisibiladadeRepSenha.Tag = "true";
                }
                else
                {
                    pnlVisibiladadeRepSenha.BackgroundImage = new Bitmap(AcroniUI.Properties.Resources.olhoblock);
                    txtCadRepPass.isPassword = true;
                    pnlVisibiladadeRepSenha.Tag = "false";
                }
            }
        }

        private void txtBoxesLogin_OnValueChanged(object sender, EventArgs e)
        {
            pnlQueDesce.Location = new Point(47, 417);
            lblAviso.Visible = false;
            pnlShowCadError.Location = new Point(94, 508);
            Bunifu.Framework.UI.BunifuMaterialTextbox b = (Bunifu.Framework.UI.BunifuMaterialTextbox)sender;
            if (b.Name.Contains("Senha") && pnlVisibiladade.Tag.Equals("false"))
                txtSenha.isPassword = true;
            if (b.Name.Contains("CadPass") && pnlVisibilidadeCadSenha.Tag.Equals("false"))
                txtCadPass.isPassword = true;
            if (b.Name.Contains("RepPass") && pnlVisibiladadeRepSenha.Tag.Equals("false"))
                txtCadRepPass.isPassword = true;
        }

        private void txtBoxesCad_OnValueChanged(object sender, EventArgs e) => pnlShowCadError.Location = new Point(94, 508);

        private void ChangeMessagelblAviso(String message)
        {
            lblAvisoCad.Text = message;
            pnlShowCadError.Location = new Point(apnlApelido.Location.X, 510);
        }

        private void MetodoParaCriarPerfilADM()
        {
            Share.User = new User();

            using (FileStream savearchive = new FileStream($@"{Application.StartupPath}\..\..\{txtEntrar.Text}.acr", FileMode.Create))
            {
                BinaryFormatter Serializer = new BinaryFormatter();
                Serializer.Serialize(savearchive, Share.User);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (hasEmptyRegisters())
                ChangeMessagelblAviso($"Ainda há registros vazios!");
            else
            {
                if (SQLMethods.SELECT_HASROWS($"SELECT usuario FROM tblCliente WHERE usuario LIKE '{txtCadApelido.Text}'"))
                    ChangeMessagelblAviso($"O apelido já existe!");
                else
                {
                    if (!Regex.IsMatch(txtCadEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                        ChangeMessagelblAviso($"O email {txtCadEmail.Text} não está correto");
                    else
                    {
                        if (SQLMethods.SELECT_HASROWS($"SELECT email FROM tblCliente WHERE email LIKE '{txtCadEmail.Text}'"))
                            ChangeMessagelblAviso($"O email {txtCadEmail.Text} existe em OUTRA conta");
                        else
                        {
                            if (!txtCadPass.Text.Equals(txtCadRepPass.Text))
                                ChangeMessagelblAviso("As senhas estão erradas");
                            else
                            {
                                this.AddOwnedForm(GetLayerForm());
                                TimerFade.Start();
                                FrmConfirmarEmail confirm = new FrmConfirmarEmail(txtCadUser.Text, txtCadApelido.Text, txtCadPass.Text, txtCadEmail.Text, txtCadCPF.Text, "cadastro");
                                if (confirm.IsDisposed)
                                    TimerFade.Start();
                                else
                                {
                                    confirm.ShowDialog();
                                    Application.OpenForms["LayerFadeForm"].Close();
                                    if (FrmConfirmarEmail.atualizacao_SUCCESS)
                                    {
                                        SQLConnection.nome_usuario = txtCadApelido.Text;
                                        Share.User = new User();
                                        //(new AcroniControls.AcroniMessageBoxConfirm("Cadastro concluido!")).Show();
                                        if (!File.Exists($@"{Application.StartupPath}\..\..\{txtEntrar.Text}.acr"))
                                        {
                                            using (FileStream savearchive = new FileStream($@"{Application.StartupPath}\..\..\{txtEntrar.Text}.acr", FileMode.OpenOrCreate))
                                            {
                                                BinaryFormatter Serializer = new BinaryFormatter();
                                                Serializer.Serialize(savearchive, Share.User);
                                            }
                                        }
                                        (new SelectKeyboard()).Show();
                                        this.Hide();
                                        // Checa se existe o arquivo, e se não existe, cria - o
                                    }
                                    else
                                    {
                                        TimerFade.Start();
                                        ChangeMessagelblAviso("Cadastro não concluído");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AcceptButton = btnEntrar;
            if (pnlCadastro.Tag.Equals("Closed"))
            {
                pnlCadastro.BringToFront();
                pnlLogin.Hide();
                while (pnlCadastro.Location.X != 0)
                {
                    pnlCadastro.Location = new Point(pnlCadastro.Location.X - 20, 0);
                    await Task.Delay(15);
                }

                pnlCadastro.Tag = "Open";
            }
            else if (pnlCadastro.Tag.ToString().Equals("Open"))
            {
                pnlCadastro.Location = new Point(800, 0);
                pnlLogin.Show();
                pnlCadastro.Tag = "Closed";
            }
        }

        private void OnLeaveValidation(object sender, EventArgs e)
        {
            if (((Bunifu.Framework.UI.BunifuMaterialTextbox)sender).Equals(txtCadApelido))
            {
                if (SQLMethods.SELECT_HASROWS($"SELECT usuario FROM tblCliente WHERE usuario LIKE '{txtCadApelido.Text}'"))
                    ChangeReferencesOnError(ref alblApelido, Color.Firebrick, ref apnlApelido, ref txtCadUser, $"O apelido {txtCadApelido.Text} já existe!");
                else
                {
                    ChangeReferencesOnError(ref alblApelido, Color.FromArgb(98, 118, 125), ref apnlApelido, ref txtCadUser, "Apelido");
                    apnlApelido.CreateGraphics().Clear(Color.FromArgb(44, 47, 55));
                }
            }
            else if (((Bunifu.Framework.UI.BunifuMaterialTextbox)sender).Equals(txtCadEmail))
            {
                if (!Regex.IsMatch(txtCadEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    ChangeReferencesOnError(ref alblEmail, Color.Firebrick, ref apnlEmail, ref txtCadEmail, $"O email está com formato incorreto!");
                else if (SQLMethods.SELECT_HASROWS($"SELECT email FROM tblCliente WHERE email LIKE '{txtCadEmail.Text}'"))
                    ChangeReferencesOnError(ref alblEmail, Color.Firebrick, ref apnlEmail, ref txtCadEmail, $"O email já existe em outra conta!");
                else
                {
                    ChangeReferencesOnError(ref alblEmail, Color.FromArgb(98, 118, 125), ref apnlEmail, ref txtCadEmail, "Email");
                    apnlEmail.CreateGraphics().Clear(Color.FromArgb(44, 47, 55));
                }
            }
            else if (((Bunifu.Framework.UI.BunifuMaterialTextbox)sender).Equals(txtCadCPF))
            {
                if (!Validator.IsCPF(txtCadCPF.Text))
                    ChangeReferencesOnError(ref alblCPF, Color.Firebrick, ref apnlCPF, ref txtCadCPF, $"O CPF não existe!!");
                else
                {
                    ChangeReferencesOnError(ref alblCPF, Color.FromArgb(98, 118, 125), ref apnlCPF, ref txtCadCPF, "CPF");
                    apnlCPF.CreateGraphics().Clear(Color.FromArgb(44, 47, 55));
                }
            }

        }
        public void CleanAllTextbox()
        {
            foreach (Control control in pnlLogin.Controls)
            {
                foreach (Control controlInside in control.Controls)
                    if (controlInside is Bunifu.Framework.UI.BunifuMaterialTextbox)
                        controlInside.ResetText();
            }
            foreach (Control control in pnlCadastro.Controls)
            {
                foreach (Control controlInside in control.Controls)
                    if (controlInside is Bunifu.Framework.UI.BunifuMaterialTextbox)
                        controlInside.ResetText();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            FadeIn();
        }

        private void alblAcroni_Click(object sender, EventArgs e)
        {
            txtEntrar.Text = "teste";
            txtSenha.Text = "teste";
            MetodoParaCriarPerfilADM();
            btnEntrar_Click(default(object), default(EventArgs));
        }

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
    }
}