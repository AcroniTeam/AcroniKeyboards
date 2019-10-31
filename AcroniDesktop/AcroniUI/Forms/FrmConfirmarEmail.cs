using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading;
using AcroniLibrary;
using AcroniLibrary.SQL;

namespace AcroniUI.LoginAndSignUp
{
    
    public partial class FrmConfirmarEmail : Form
    {
        private void Start_SplashScreen()
        {
            Application.Run(new Splash());
        }

        private String email_public, senha_public, usuario_public, nome_public,tipo_public, String_de_confirmacao = "",cpf_public = "";
        Thread t_splash;

        public static bool atualizacao_SUCCESS;

        #region Construtor em mudança de senha
        public FrmConfirmarEmail(String usuario, String senha, String email, String tipo)
        {
            Thread t_splash = new Thread(new ThreadStart(Start_SplashScreen));
            t_splash.Start();

            InitializeComponent();
            
            //--Retiranado as variaveis do construtor (já validadas)
            usuario_public = usuario;
            senha_public = senha;
            email_public = email;
            tipo_public = tipo;
            
            gerar_string_confirmacao();

            //--Enviando o numero para o email da pessoa
            btnReenviar_Click(default(object), default(LinkLabelLinkClickedEventArgs));
            t_splash.Abort();

            //--Mudando o nome do label de acordo com a necessidade
            lblTitulo.Text = tipo.Equals("cadastro")?"Cadastrando o seu usuário":"Atualizando a sua senha";
        }
        #endregion

        #region Construtor em cadastro
        public FrmConfirmarEmail(String nome, String usuario, String senha, String email, String cpf, String tipo)
        {
            t_splash = new Thread(new ThreadStart(Start_SplashScreen));
            t_splash.Start();
            InitializeComponent();
            
            //--Retiranado as variaveis do construtor (já validadas)
            usuario_public = usuario;
            senha_public = senha;
            email_public = email;
            tipo_public = tipo;
            cpf_public = cpf;
            nome_public = nome;

            gerar_string_confirmacao();

            //--Enviando o numero para o email da pessoa
            object c = null; LinkLabelLinkClickedEventArgs e = null;
            btnReenviar_Click(c, e);
            t_splash.Abort();
            //--Mudando o nome do label de acordo com a necessidade
            lblTitulo.Text = tipo.Equals("cadastro") ? "Cadastrando o seu usuário" : "Atualizando a sua senha";
            
        }
        #endregion
        
        private void btnReenviar_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //--Lembrem-se disso como se fosse Excel -> Se () ? então se VERDADEIRO : se FALSO 
            String titulo = (tipo_public.Equals("cadastro")?"Fazendo o seu cadastro":(tipo_public.Equals("senha")?"Atualização de senha":"--Unknown--"));
            //String mensagem = "Olá " + select_usuario() + ". O número certo é " + numero_certo;
            String mensagem = $"Olá {usuario_public}!\nInsira o código para confirmar " + (tipo_public.Equals("cadastro")? "o seu cadastro." : "a sua atualização de senha.") + "\n\n" + String_de_confirmacao;
            try
            {
                MailMessage objeto_mail = new MailMessage("acroni.acroni7@gmail.com", email_public, titulo, mensagem);
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                //client.Credentials = new System.Net.NetworkCredential("noreply@acroni.rf.gd", "facilbaba1234");
                client.Credentials = new System.Net.NetworkCredential("acroni.acroni7@gmail.com", "acroni77");
                client.EnableSsl = true;
                client.Send(objeto_mail);
            }
            catch (Exception)
            {
                t_splash.Abort();
                (new AcroniControls.MessageBoxSemInternet()).ShowDialog();
                this.Close();
            }
        }

        private void btnEnviar_MouseEnter(object sender, EventArgs e)
        {
            //pnlSquareLeftBorderBtnEnviar.BackColor = Color.FromArgb(0, 180, 255);
            btnEnviar.BackColor = Color.FromArgb(0, 180, 255);
            //MessageBox.Show($"{btnEnviar.BackColor}");
        }

        private void btnEnviar_MouseLeave(object sender, EventArgs e)
        {
            //pnlSquareLeftBorderBtnEnviar.BackColor = Color.DodgerBlue;
            btnEnviar.BackColor = Color.DodgerBlue;
        }

        //--Inicializando uma conexão e um COMANDO
        SqlConnection conexao_SQL = new SqlConnection(SQLConnection.nome_conexao);
        SqlCommand comando_SQL;


        private void btnEnviar_Click(object sender, EventArgs e)
        {            
            if (txtCodigo.Text.ToUpper().Equals(String_de_confirmacao))
            {
                SQLConnection.nome_usuario = usuario_public;
                atualizacao_SUCCESS = true;
                if (tipo_public.Equals("cadastro"))
                    SQLProcMethods.INSERT_CadastroCliente(nome_public.Replace(' ','-'), usuario_public, senha_public, email_public, cpf_public);
                else if (tipo_public.Equals("senha"))
                    SQLProcMethods.UPDATE_Senha(senha_public,email_public);
                Close();
            }
            else
            { 
                atualizacao_SUCCESS = false;
                this.Close();
            }
        }

        private void insert()
        {
            try
            {
                //--Abrindo a conexão
                if (conexao_SQL.State != ConnectionState.Open)
                    conexao_SQL.Open();

                //--Lendo a imagem e a convertendo em array binário
                //FileStream leitor_imagem = new FileStream(localizacao_img_public, FileMode.Open, FileAccess.Read);
                //BinaryReader convertedor_binario = new BinaryReader(leitor_imagem);
                //img = convertedor_binario.ReadBytes((int)leitor_imagem.Length);

                //--Inicializando um comando INSERT e execuntando
                String insert = "INSERT INTO tblCliente(usuario,senha,email) VALUES ('" + usuario_public + "','" + senha_public + "','" + email_public + "')";
                comando_SQL = new SqlCommand(insert, conexao_SQL);
                //comando_SQL.Parameters.AddWithValue("@img", img);

                //--Para executar, utilizo ExecuteNonQuery(), pois ele retorna apenas o numero de linhas afetadas
                int n_linhas_afetadas = comando_SQL.ExecuteNonQuery();
                //--Fechando a conexão (NÃO ESQUECER!)
                conexao_SQL.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexao_SQL.Close();
            }
        }

        private String select_usuario()
        {
            try
            {
                if (conexao_SQL.State == ConnectionState.Closed)
                    conexao_SQL.Open();

                String select = "SELECT usuario FROM tblCliente WHERE email = '" + email_public + "'";
                comando_SQL = new SqlCommand(select, conexao_SQL);
                SqlDataReader resposta = comando_SQL.ExecuteReader();

                resposta.Read();
                String usuario = resposta[0].ToString();
                resposta.Close();
                conexao_SQL.Close();
                return usuario;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                conexao_SQL.Close();
                return usuario_public;
            }
        }
        

        private void gerar_string_confirmacao()
        {
            //--Continuar mudança
            char[] alfabeto = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            Random r = new Random();
            for (int i = 0; i < 7; i++) {
                if (r.Next(2) == 0)
                {
                    //alfabeto
                    String_de_confirmacao += alfabeto[r.Next(26)];
                }else
                {
                    //numero
                    String_de_confirmacao += r.Next(10);
                }
            }
        }
    }
}
