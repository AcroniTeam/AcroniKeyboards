using AcroniControls;
using AcroniLibrary.FileInfo;
using AcroniLibrary.SQL;
using AcroniUI.Custom;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcroniLibrary.FirebaseData;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp.Config;


namespace AcroniUI
{
    public partial class Galeria : TemplateMenu
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source = " + Environment.MachineName + "\\SQLEXPRESS; Initial Catalog = ACRONI_SQL; User ID = Acroni; Password = acroni7");
        int countHeightCollection = 0;
        int countWidthKeyboard = 0;
        bool selectMode;

        #region Firebase instances

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "SkeKuTHfj9sk7hZbKB91MTgcsvCzGw54M7timKeA",
            BasePath = "https://analytics-7777.firebaseio.com/"
        };

        IFirebaseClient client;
        #endregion


        void Splash()
        {
            Application.Run(new Splash());
        }
        public Galeria(bool selectMode)
        {
            InitializeComponent();
            Thread spl = new Thread(new ThreadStart(Splash));
            spl.Start();
            WelcomeUser();
            this.selectMode = selectMode;

            if (selectMode)
            {
                lblBoasVindas.Visible = false;
                lblNomeUsuBoasVindas.Visible = false;
                lblSavedCollections1.Visible = false;
                lblColecoesSalvas2.Visible = false;
                lblCollectionsQuantity.Visible = false;
                lblSelectKeyboard.Visible = true;
            }
            if (!DesignMode)
                LoadCollections();

            #region Adicionar evento de click ao btnEditarGaleria e btnExcluirGaleria
            if (!DesignMode)
                foreach (Control collection in pnlScroll.Controls)
                {
                    if (collection is CollectionUI)
                    {
                        foreach (Control itemColecao in collection.Controls)
                        {
                            if (itemColecao.Name.Equals("btnEditarGaleria"))
                                itemColecao.Click += new EventHandler(Edit);
                            else if (itemColecao.Name.Equals("btnExcluirGaleria"))
                                itemColecao.Click += new EventHandler(Exclude);
                        }
                    }
                }

            #endregion
            spl.Abort();
        }

        public void WelcomeUser() => lblNomeUsuBoasVindas.Text = SQLConnection.nome_usuario + "!";

        #region Carregar Coleções

        private void LoadCollections()
        {
            using (FileStream openarchive = new FileStream($@"{Application.StartupPath}\Users\{SQLConnection.nome_usuario}.acr", FileMode.OpenOrCreate))
            {
                BinaryFormatter ofByteArrayToObject = new BinaryFormatter();
                Share.User = (User)ofByteArrayToObject.Deserialize(openarchive);
            }

            int countCollections = 0;

            try
            {
                if (countCollections != 0)
                    pnlScroll.BackgroundImage = null;

                foreach (Collection userCollection in Share.User.UserCollections)
                {
                    foreach (Keyboard k in userCollection.Keyboards)
                    {
                        Share.KeyboardsQuantity++;
                        Share.Keyboard.NickName = k.NickName;
                        ControlKeyboard controlKeyboard = new ControlKeyboard();
                        controlKeyboard.Click += new EventHandler(OpenKeyboard);
                        controlKeyboard.ForeColor = SystemColors.Control;
                        controlKeyboard.Location = new Point(countWidthKeyboard += 13, 10);
                        ControlKeyboard_Collections.keyboardsControl.Add(controlKeyboard);
                        countWidthKeyboard += 83;
                    }

                    Share.Collection.CollectionColor = userCollection.CollectionColor;
                    Share.Collection.CollectionName = userCollection.CollectionName;
                    Share.CollectionsName.Add(userCollection.CollectionName);
                    //Chama o controle de usuário
                    CollectionUI collectionUi = new CollectionUI();
                    collectionUi.MouseEnter += new EventHandler(changeColor_MouseEnter);
                    collectionUi.MouseLeave += new EventHandler(returnColor_MouseLeave);
                    collectionUi.Click += new EventHandler(collectionUi_Click);
                    collectionUi.Location = new Point(16, 8 + countHeightCollection);
                    foreach (Control c in collectionUi.Controls)
                        if (c is Panel)
                        {
                            c.Click += new EventHandler(collectionUi_Click);
                            break;
                        }
                    pnlScroll.Controls.Add(collectionUi);
                    Share.KeyboardsQuantity = 0;
                    Share.Collection.CollectionName = "";
                    Share.Keyboard.Name = "";
                    countWidthKeyboard = 0;
                    countCollections++;
                    countHeightCollection += 179;
                    ControlKeyboard_Collections.keyboardsControl = new List<ControlKeyboard>();
                }
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            lblCollectionsQuantity.Text = Convert.ToString(countCollections);
        }

        #endregion

        private void collectionUi_Click(object sender, EventArgs e)
        {
            Panel painelkapakapaALO;
            Regex keyboardsQuantity = new Regex(@"• \d+ Teclados");
            if (!(sender as Panel).Parent.Name.Equals("pnlScroll"))
                painelkapakapaALO = (Panel)(sender as Panel).Parent;
            else
                painelkapakapaALO = (sender as Panel);
            foreach (Control items in painelkapakapaALO.Controls)
            {
                if (!(keyboardsQuantity.IsMatch(items.Text)))
                {
                    foreach (Collection userCollection in Share.User.UserCollections)
                        if (userCollection.CollectionName.Equals(items.Text))
                            Share.Collection = userCollection;
                }
            }
            if (!selectMode)
            {
                CollectionSelected openSelectedCollection = new CollectionSelected();
                openSelectedCollection.Show();
            }
            this.Close();
            Share.KeyboardsQuantity = 0;
        }
        private void changeColor_MouseEnter(object sender, EventArgs e)
        {
            (sender as Panel).BackColor = Color.FromArgb(195, (sender as Panel).BackColor.R, (sender as Panel).BackColor.G, (sender as Panel).BackColor.B);

        }
        private void returnColor_MouseLeave(object sender, EventArgs e)
        {
            (sender as Panel).BackColor = Color.FromArgb(255, (sender as Panel).BackColor.R, (sender as Panel).BackColor.G, (sender as Panel).BackColor.B);
        }

        private string getActualMonth()
        {
            int nMes = DateTime.Today.Month;
            string[] meses = new string[12] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho",
            "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"};
            return meses[nMes - 1];
        }

        private void btnAdicionarGaleria_Click(object sender, EventArgs e)
        {
            short contcollections = 0;
            if (!Share.User.isPremiumAccount)
                foreach (Collection col in Share.User.UserCollections)
                    contcollections++;
            if (contcollections < 1 || Share.User.isPremiumAccount)
            {
                AcroniMessageBoxInput collectionNameDialog = new AcroniMessageBoxInput("Insira o nome de sua coleção:");
                if (collectionNameDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(collectionNameDialog.input))
                    {
                        if (collectionNameDialog.alblMessage.Contains("coleção"))
                            Share.Collection.CollectionName = collectionNameDialog.input;
                        else
                            Share.KeyboardNameNotCreated = collectionNameDialog.input;
                    }

                }
                if (!string.IsNullOrEmpty(Share.Collection.CollectionName))
                {
                    Collection newCollection = new Collection();

                    newCollection.CollectionName = Share.Collection.CollectionName;
                    newCollection.CollectionColor = Color.DimGray;

                    Share.User.UserCollections.Add(newCollection);

                    Share.Collection.CollectionName = newCollection.CollectionName;

                    AcroniControls.CollectionUI collectionUi = new AcroniControls.CollectionUI();

                    collectionUi.MouseEnter += new EventHandler(changeColor_MouseEnter);
                    collectionUi.MouseLeave += new EventHandler(returnColor_MouseLeave);


                    foreach (Control itemColecao in collectionUi.Controls)
                    {
                        if (itemColecao.Name.Equals("btnEditarGaleria"))
                        {
                            itemColecao.Click += new EventHandler(Edit);
                        }
                        else if (itemColecao.Name.Equals("btnExcluirGaleria"))
                        {
                            itemColecao.Click += new EventHandler(Exclude);
                        }
                    }

                    collectionUi.Click += new EventHandler(collectionUi_Click);
                    collectionUi.Location = new Point(16, 8 + countHeightCollection);
                    countHeightCollection += 179;
                    collectionUi.BackColor = newCollection.CollectionColor;
                    pnlScroll.Controls.Add(collectionUi);
                    Share.User.SendToFile();
                    lblCollectionsQuantity.Text = Convert.ToString(Convert.ToInt16(lblCollectionsQuantity.Text) + 1);
                    Share.KeyboardsQuantity = 0;
                    Share.Collection.CollectionName = "";
                    Share.Keyboard.Name = "";


                    DataAnalyticalSender();

                }

            }
            else
            {
                AcroniMessageBoxConfirm mb = new AcroniMessageBoxConfirm("Sinto muito, mas você atingiu o limite de coleções que você " +
                                                       "pode criar usando essa conta.", "Atualize sua conta agora mesmo para uma conta Premium");
                mb.ShowDialog();
            }
        }

        private async void DataAnalyticalSender()
        {
            #region Relatório global Firebase
            // Estratégia: apenas dar um patch nos dados existentes
            // Pega-se o valor anterior e incrementa-o por mais um

            // Gerando um cliente que será o objeto conexão usando a chave do banco
            client = new FireSharp.FirebaseClient(config);


            if (Share.User.isPremiumAccount)
            {
                FirebaseResponse responseGlobal = await client.
                    GetAsync("/relatoriosGlobais/desktop");
                GlobalData previousGlobal = responseGlobal.ResultAs<GlobalData>();


                var relatorioGlobal = new GlobalData
                {
                    tecladosProduzidosPorUsuariosPremium = ++previousGlobal.tecladosProduzidosPorUsuariosPremium
                };

                await client.UpdateAsync("/relatoriosGlobais/desktop", relatorioGlobal);

            }
            #endregion

            try
            {
                FirebaseResponse response = await client.
                GetAsync("/relatoriosMensais/desktop/" + DateTime.Today.Year);

                try
                {
                    response = await client.GetAsync("/relatoriosMensais/desktop/" + DateTime.Today.Year + "/" + getActualMonth());
                    MensalData previousMensal = response.ResultAs<MensalData>();
                    var relatorioMensal = new MensalData
                    {
                        qntTecladosProduzidosPorMes = ++previousMensal.qntTecladosProduzidosPorMes
                    };

                    await client.UpdateAsync("/relatoriosMensais/desktop/" + DateTime.Today.Year + "/" + getActualMonth(), relatorioMensal);
                }
                catch (SqlException ex)
                {
                    var mes = new Mes
                    {
                        mes = getActualMonth()
                    };
                    await client.UpdateAsync("/relatoriosMensais/desktop/" + DateTime.Today.Year, mes);
                }
            }
            catch (SqlException ex)
            {
                var ano = new Ano
                {
                    ano = DateTime.Today.Year
                };
                await client.UpdateAsync("/relatoriosMensais/desktop/", ano);
            }

        }

        private void Exclude(object sender, EventArgs e)
        {
            if (!selectMode)
            {
                AcroniMessageBoxConfirm confirmExclude = new AcroniMessageBoxConfirm("Deseja mesmo excluir esta coleção?", "Não terá como reverter o processo O_O");
                if (confirmExclude.ShowDialog() == DialogResult.Yes)
                {
                    foreach (Control c in ((sender as PictureBox).Parent as Panel).Controls)
                    {
                        if (c.Name.Equals("lblColecao1"))
                        {
                            foreach (Collection collection in Share.User.UserCollections)
                            {
                                if (collection.CollectionName.Equals(c.Text))
                                {
                                    Share.User.UserCollections.Remove(collection);
                                    foreach (Keyboard k in collection.Keyboards)
                                        Share.User.KeyboardQuantity--;
                                    SQLProcMethods.DELETE_TecladosCustomizadosFrom(Share.User.ID);
                                    SQLProcMethods.DELETE_ColecaoFrom(Share.User.ID, c.Text);
                                    break;
                                }
                            }
                        }
                    }
                    this.UpdateKeyboardQuantity();
                    Share.User.SendToFile();
                    Galeria recharge = new Galeria(false);
                    recharge.Show();
                    this.Close();
                }
            }
            else
            {
                AcroniMessageBoxConfirm afa = new AcroniMessageBoxConfirm("Não podes excluir a coleção agora", "Sinto muito, mas quando vai salvar o teclado, não há a possibilidade de deletar as coleções");
                afa.ShowDialog();
            }
        }

        private void OpenKeyboard(object sender, EventArgs e)
        {
            foreach (Control itemsGallery in (((sender as Button).Parent as Panel).Parent as Panel).Controls)
            {
                if (itemsGallery.Name.Equals("lblColecao1"))
                {
                    foreach (Collection keyBoardGallery in Share.User.UserCollections)
                    {
                        if (keyBoardGallery.CollectionName.Equals(itemsGallery.Text))
                        {
                            foreach (Keyboard keyboardToOpen in keyBoardGallery.Keyboards)
                            {
                                if (keyboardToOpen.NickName.Equals((sender as Button).Text))
                                {
                                    Share.Keyboard = keyboardToOpen;
                                    Form editarTeclado = null;
                                    Share.EditKeyboard = true;
                                    Share.Collection.CollectionName = keyBoardGallery.CollectionName;
                                    editarTeclado = new Compacto();
                                    editarTeclado.Show();
                                    this.Close();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        SelectColor selectColor;
        bool canclose = false;
        public async void Edit(object sender, EventArgs e)
        {
            if (!selectMode)
            {
                if (canclose)
                    selectColor.Close();
                else
                {
                    foreach (Control itemsGallery in (((sender as PictureBox).Parent as Panel)).Controls)
                        if (itemsGallery.Name.Equals("lblColecao1"))
                            selectColor = new SelectColor(itemsGallery.Text);
                    selectColor.Show();
                    canclose = true;
                    while (selectColor.Visible)
                    {
                        await Task.Delay(10);
                        if (selectColor.SettedColor != Color.Empty)
                            ((sender as PictureBox).Parent as Panel).BackColor = selectColor.SettedColor;
                    }
                    if (selectColor.SettedColor != Color.Empty || !string.IsNullOrEmpty(selectColor.CollectionName))
                    {
                        foreach (Control c in ((sender as PictureBox).Parent as Panel).Controls)
                        {
                            if (c.Name.Equals("lblColecao1"))
                            {
                                foreach (Collection collection in Share.User.UserCollections)
                                {
                                    if (collection.CollectionName.Equals(c.Text))
                                    {
                                        if (selectColor.SettedColor != Color.Empty)
                                            collection.CollectionColor = selectColor.SettedColor;
                                        if (!string.IsNullOrEmpty(selectColor.CollectionName))
                                        {
                                            List<Object> id = SQLProcMethods.SELECT_IdColecao(collection.CollectionName, Share.User.ID);
                                            SQLProcMethods.UPDATE_Colecao(selectColor.CollectionName, Share.User.ID, (int)id[0]);
                                            collection.CollectionName = selectColor.CollectionName;
                                        }
                                        Share.User.SendToFile();
                                        Galeria recharge = new Galeria(false);
                                        recharge.Show();
                                        this.Close();
                                        break;
                                    }
                                }
                            }
                        }
                        Share.User.SendToFile();
                    }
                }
            }
            else
            {
                AcroniMessageBoxConfirm afa = new AcroniMessageBoxConfirm("Não podes editar a coleção agora", "Sinto muito, mas quando vai salvar o teclado, não há a possibilidade de customizar as coleções");
                afa.ShowDialog();
            }
        }
        protected override void btnClose_Click(object sender, EventArgs e)
        {
            base.btnClose_Click(sender, e);
        }
        private async void btnAdicionarGaleria_MouseEnter(object sender, EventArgs e)
        {
            await Task.Delay(50);
            btnAdicionarGaleria.Size = new Size(btnAdicionarGaleria.Size.Width + 10, btnAdicionarGaleria.Size.Height + 10);
            btnAdicionarGaleria.Location = new Point(btnAdicionarGaleria.Location.X - (10 / 2), btnAdicionarGaleria.Location.Y - (10 / 2));

        }

        private async void btnAdicionarGaleria_MouseLeave(object sender, EventArgs e)
        {
            await Task.Delay(50);
            btnAdicionarGaleria.Size = new Size(btnAdicionarGaleria.Size.Width - 10, btnAdicionarGaleria.Size.Height - 10);
            btnAdicionarGaleria.Location = new Point(btnAdicionarGaleria.Location.X + (10 / 2), btnAdicionarGaleria.Location.Y + (10 / 2));
        }


    }
}