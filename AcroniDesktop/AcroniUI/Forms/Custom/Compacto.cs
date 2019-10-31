using System;
using System.Windows.Forms;
using System.Drawing;
using Transitions;
using AcroniControls;
using System.Collections.Generic;
using AcroniLibrary.CustomizingMethods.TextFonts;
using AcroniLibrary.FileInfo;
using AcroniUI.Custom.CustomModules;
using System.Threading.Tasks;
using AcroniLibrary.Drawing;
using System.Drawing.Imaging;
using Bunifu.Framework.UI;
using AcroniLibrary.SQL;
using System.Data;
using System.Threading;

namespace AcroniUI.Custom
{
    public partial class Compacto : Template
    {
        #region Declarações 

        // Definição do botão de teclado genérico (kbtn)
        Label keybutton;
        int paintedKeycapsCounter = 0;
        // Definição das propriedades de salvamento
        //private bool SetKeyboardProperties;
        Keyboard keyboard = new Keyboard();
        Collection collection = new Collection();

        //Definição das propriedades das fontes
        ContentAlignment ContentAlignment { get; set; }
        private static List<FontFamily> lista_fontFamily = new List<FontFamily>();

        // Definição das propriedades do colorpicker 
        private FontStyle __fontStyle { get; set; } = FontStyle.Regular;
        private object __contentAlignment { get; set; } = ContentAlignment.TopLeft;

        //Cores do fundo e da fonte
        private Color Color { get; set; } = Color.FromArgb(26, 26, 26);
        private Color FontColor { get; set; } = Color.White;

        // Definição de PictureBox privada que conterá a imagem de fundo para aplicação do efeito de Blur.
        private PictureBox __PictureBox { get; set; }
        private Panel __pnl { get; set; }


        #endregion

        #region Implementações do menu de arquivos
        private bool personalSave = false;
        private int isFirstSave = 0; 
        protected override void lblSalvar_Click(object sender, EventArgs e)
        {
            if (isFirstSave++ == 0)
            {
                personalSave = true;
                btnSalvar_Click(sender, e);
            }
            else
            {
                personalSave = false;
                btnSalvar_Click(sender, e);
            }
        }

        protected override void lblAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecione o arquivo de teclado";
            ofd.Filter = "Acroni Keyboard (*.acrk)|*.acrk";
            if (ofd.ShowDialog() == DialogResult.OK)
                LoadKeyboard();
        }

        protected override void lblSalvarComo_Click(object sender, EventArgs e)
        {
            personalSave = true;
            btnSalvar_Click(sender, e);
        }
        #endregion

        #region Implementações dos botões do template (pnlSuperior)

        protected override void btnMax_Click(object sender, EventArgs e)
        {
            base.btnMax_Click(sender, e);
            if (this.WindowState == FormWindowState.Normal)
            {
                lblCollectionName.Location = new Point(300, 35);
                lblKeyboardName.Location = new Point(609, 35);
                btnSalvar.Location = new Point(1100, 35);
                pnlBodyColorpicker.Location = new Point(915, (this.Height - pnlBodyColorpicker.Height + pnlHeadColorpicker.Height) / 2);
                pnlHeadColorpicker.Location = new Point(915, (this.Height - pnlHeadColorpicker.Height - pnlBodyColorpicker.Height) / 2);
                apnlCustomOptionsLeft.Location = new Point(0, 0);
                apnlCustomOptionsRight.Location = new Point(878, 0);
                picBoxKeyboardBackground.Location = new Point(
                    this.Width - picBoxKeyboardBackground.Width / 2 - pnlBodyColorpicker.Width,
                    this.Height - picBoxKeyboardBackground.Height / 2 - (pnlCustomizingMenu.Height + 40)

                    );
            }
            else
            {
                lblCollectionName.Location = new Point((this.Width - (2 * lblCollectionName.Width)) / 2, (pnlCustomizingMenu.Height - lblCollectionName.Height) / 2);
                lblKeyboardName.Location = new Point((this.Width - (2 * lblKeyboardName.Width)) / 2, (pnlCustomizingMenu.Height - lblKeyboardName.Height) / 2);
                btnSalvar.Location = new Point(this.Width - btnSalvar.Width - 20, (pnlCustomizingMenu.Height - lblCollectionName.Height) / 2);
                pnlBodyColorpicker.Location = new Point(this.Width - pnlBodyColorpicker.Width - 60, (this.Height - pnlBodyColorpicker.Height + pnlHeadColorpicker.Height) / 2);
                pnlHeadColorpicker.Location = new Point(this.Width - pnlHeadColorpicker.Width - 60, (this.Height - pnlHeadColorpicker.Height - pnlBodyColorpicker.Height) / 2);
                apnlCustomOptionsLeft.Location = new Point(this.Width * 2 / 3, 0);
                apnlCustomOptionsRight.Location = new Point(this.Width * 2 / 3, 0);
            }
            
        }

        #endregion

        #region Eventos a nível do formulário
        private void lblUpperBottom_Click(object sender, EventArgs e)
        {
            kbtn_Click(sender, e);
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            if (btnOpenModuleTextIcons.Tag.Equals("active"))
            {
                btnOpenModuleTextIcons.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleTextIcons.Tag = "disable";
            }
            else if (btnOpenModuleTexture.Tag.Equals("active"))
            {
                btnOpenModuleTexture.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleTexture.Tag = "disable";
            }
            else if (btnOpenModuleSwitch.Tag.Equals("active"))
            {
                btnOpenModuleSwitch.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleSwitch.Tag = "disable";
            }
            //Isso serve para gerenciar e saber quais estilos foram selecionados.
            Button style = (Button)sender;

            //Fácil: Se está ativo, desative. Isso para os botões de estilização da fonte.
            if (style.Tag.Equals("active"))
            {
                style.Tag = "disabled";
                style.BackColor = Color.FromArgb(35, 36, 38);
            }
            else
            {
                style.Tag = "active";
                style.BackColor = Color.FromArgb(80, 80, 80);
            }

            #region Combinações de estilo das fontes: 

            // Essas são as possíveis combinações de estilos de fontes:

            if (btnStyleBold.Tag.Equals("active") && btnStyleItalic.Tag.Equals("active") && btnStyleUnderline.Tag.Equals("active"))
                __fontStyle = FontStyle.Bold | FontStyle.Italic | FontStyle.Underline;

            else if (btnStyleBold.Tag.Equals("active") && btnStyleItalic.Tag.Equals("active"))
                __fontStyle = FontStyle.Bold | FontStyle.Italic;

            else if (btnStyleBold.Tag.Equals("active") && btnStyleStrikeout.Tag.Equals("active"))
                __fontStyle = FontStyle.Bold | FontStyle.Strikeout;

            else if (btnStyleBold.Tag.Equals("active") && btnStyleUnderline.Tag.Equals("active"))
                __fontStyle = FontStyle.Bold | FontStyle.Underline;

            else if (btnStyleBold.Tag.Equals("active") && btnStyleItalic.Tag.Equals("active") && btnStyleStrikeout.Tag.Equals("active"))
                __fontStyle = FontStyle.Bold | FontStyle.Italic | FontStyle.Strikeout;

            else if (btnStyleItalic.Tag.Equals("active") && btnStyleUnderline.Tag.Equals("active") && btnStyleStrikeout.Tag.Equals("active"))
                __fontStyle = FontStyle.Italic | FontStyle.Underline | FontStyle.Strikeout;

            else if (btnStyleItalic.Tag.Equals("active") && btnStyleUnderline.Tag.Equals("active"))
                __fontStyle = FontStyle.Italic | FontStyle.Underline;

            else if (btnStyleItalic.Tag.Equals("active") && btnStyleStrikeout.Tag.Equals("active"))
                __fontStyle = FontStyle.Italic | FontStyle.Strikeout;

            else if (btnStyleUnderline.Tag.Equals("active") && btnStyleStrikeout.Tag.Equals("active"))
                __fontStyle = FontStyle.Underline | FontStyle.Strikeout;

            else if (btnStyleBold.Tag.Equals("active") && btnStyleUnderline.Tag.Equals("active") && btnStyleStrikeout.Tag.Equals("active"))
                __fontStyle = FontStyle.Bold | FontStyle.Underline | FontStyle.Strikeout;

            else if (btnStyleBold.Tag.Equals("active"))
                __fontStyle = FontStyle.Bold;

            else if (btnStyleItalic.Tag.Equals("active"))
                __fontStyle = FontStyle.Italic;

            else if (btnStyleUnderline.Tag.Equals("active"))
                __fontStyle = FontStyle.Underline;

            else if (btnStyleStrikeout.Tag.Equals("active"))
                __fontStyle = FontStyle.Strikeout;

            else
                __fontStyle = FontStyle.Regular;

            #endregion
        }

        #region Alinhamento dos textos
        private void VerticalContentAlignment_Click(object sender, EventArgs e)
        {
            if (btnOpenModuleTextIcons.Tag.Equals("active"))
            {
                btnOpenModuleTextIcons.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleTextIcons.Tag = "disable";
            }
            else if (btnOpenModuleTexture.Tag.Equals("active"))
            {
                btnOpenModuleTexture.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleTexture.Tag = "disable";
            }
            else if (btnOpenModuleSwitch.Tag.Equals("active"))
            {
                btnOpenModuleSwitch.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleSwitch.Tag = "disable";
            }
            foreach (Control alignButton in pnlVertAlign.Controls)
            {
                if (alignButton == (sender as BunifuImageButton))
                {
                    alignButton.Tag = "active";
                    alignButton.BackColor = Color.FromArgb(80, 80, 80);
                }
                else
                {
                    alignButton.Tag = "disabled";
                    alignButton.BackColor = Color.Transparent;
                }
            }

            if (btnTextAlignLeft.Tag.Equals("active"))
            {
                if (btnTextAlignUpper.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.TopLeft;

                if (btnTextAlignMiddle.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.MiddleLeft;

                if (btnTextAlignBottom.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.BottomLeft;
            }

            else if (btnTextAlignCenter.Tag.Equals("active"))
            {
                if (btnTextAlignUpper.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.TopCenter;

                if (btnTextAlignMiddle.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.MiddleCenter;

                if (btnTextAlignBottom.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.BottomCenter;
            }

            else if (btnTextAlignRight.Tag.Equals("active"))
            {
                if (btnTextAlignUpper.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.TopRight;

                if (btnTextAlignMiddle.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.MiddleRight;

                if (btnTextAlignBottom.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.BottomRight;
            }
        }

        private void HorizontalContentAlign_Click(object sender, EventArgs e)
        {
            if (btnOpenModuleTextIcons.Tag.Equals("active"))
            {
                btnOpenModuleTextIcons.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleTextIcons.Tag = "disable";
            }
            else if (btnOpenModuleTexture.Tag.Equals("active"))
            {
                btnOpenModuleTexture.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleTexture.Tag = "disable";
            }
            else if (btnOpenModuleSwitch.Tag.Equals("active"))
            {
                btnOpenModuleSwitch.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleSwitch.Tag = "disable";
            }
            foreach (Control alignButton in pnlHorizAlign.Controls)
            {
                if (alignButton == (sender as BunifuImageButton))
                {
                    alignButton.Tag = "active";
                    alignButton.BackColor = Color.FromArgb(80, 80, 80);
                }
                else
                {
                    alignButton.Tag = "disabled";
                    alignButton.BackColor = Color.Transparent;
                }
            }

            if (btnTextAlignLeft.Tag.Equals("active"))
            {
                if (btnTextAlignUpper.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.TopLeft;

                if (btnTextAlignMiddle.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.MiddleLeft;

                if (btnTextAlignBottom.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.BottomLeft;
            }

            else if (btnTextAlignCenter.Tag.Equals("active"))
            {
                if (btnTextAlignUpper.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.TopCenter;

                if (btnTextAlignMiddle.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.MiddleCenter;

                if (btnTextAlignBottom.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.BottomCenter;
            }

            else if (btnTextAlignRight.Tag.Equals("active"))
            {
                if (btnTextAlignUpper.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.TopRight;

                if (btnTextAlignMiddle.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.MiddleRight;

                if (btnTextAlignBottom.Tag.Equals("active"))
                    __contentAlignment = ContentAlignment.BottomRight;
            }
        }
        #endregion


        /// <summary>
        /// Método acionado ao clicar num botão do teclado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kbtn_Click(object sender, EventArgs e)
        {
            keybutton = (Label)sender;

            #region Atribuição de cores
            if (!btnOpenModuleBackground.Tag.Equals("active") && !btnOpenModuleSwitch.Tag.Equals("active") && !btnOpenModuleTexture.Tag.Equals("active") && !btnOpenModuleTextIcons.Tag.Equals("active"))
                if (btnStyleFontColor.Tag.Equals("active"))
                    keybutton.ForeColor = FontColor;

                else
                {
                    if (keybutton.BackColor == Color.FromArgb(26, 26, 26) && keybutton.BackColor != Color.FromArgb(90, Color))
                        paintedKeycapsCounter++;

                    keybutton.BackColor = Color;
                    keybutton.Parent.BackColor = Color.FromArgb(90, Color);
                    keybutton.Parent.BackgroundImage = null;
                    if (Color != Color.FromArgb(26, 26, 26))
                    {
                        lblPaintedKeycaps.Text = paintedKeycapsCounter + "";
                        if (keybutton == lblCb14sExtensao || keybutton == lblCb14s)
                        {
                            lblCb14s.Parent.BackgroundImage = null;
                            lblCb14sExtensao.Parent.BackgroundImage = null;
                            lblCb14sExtensao.BackColor = Color;
                            lblCb14sExtensao.Parent.BackColor = Color.FromArgb(90, Color);
                            lblCb14s.BackColor = Color;
                            lblCb14s.Parent.BackColor = Color.FromArgb(90, Color);
                        }
                    }
                    else
                    {
                        if (paintedKeycapsCounter > 0)
                            paintedKeycapsCounter--;
                        lblPaintedKeycaps.Text = paintedKeycapsCounter + "";
                        if (keybutton == lblCb14sExtensao || keybutton == lblCb14s)
                        {
                            lblCb14s.Parent.BackgroundImage = Image.FromFile($@"{Application.StartupPath}\Images\Teclas\lblCb14s.png");
                            lblCb14sExtensao.Parent.BackgroundImage = Image.FromFile($@"{Application.StartupPath}\Images\Teclas\lblCb14sExtensao.png");
                            lblCb14s.BackColor = Color;
                            lblCb14sExtensao.BackColor = Color;
                            lblCb14sExtensao.Parent.BackColor = Color.Black;
                            lblCb14s.Parent.BackColor = Color.Black;

                        }
                        if (keybutton.Size.Equals(new Size(38, 39)))
                            keybutton.Parent.BackgroundImage = Image.FromFile($@"{Application.StartupPath}\Images\Teclas\keycapbackgrounddefault.png");
                        else
                        {
                            keybutton.Parent.BackColor = Color.Black;
                            keybutton.Parent.BackgroundImage = Image.FromFile($@"{Application.StartupPath}\Images\Teclas\{keybutton.Name}.png");
                        }
                    }
                }

            #endregion

            #region Atribuição de fonte e estilos de fonte  
            // Isso serve para saber se nenhum botão de módulo foi escolhido. Se nenhum foi, então você pode atribuir a fonte.
            if (!btnOpenModuleBackground.Tag.Equals("active") && !btnOpenModuleSwitch.Tag.Equals("active") && !btnOpenModuleTexture.Tag.Equals("active") && !btnOpenModuleTextIcons.Tag.Equals("active"))
            {
                int __checkIfCanApplyStyle = 0;
                foreach (Control btn in pnlBtnOpenModules.Controls)
                {
                    if (btn.Tag.Equals("disable"))
                    {
                        __checkIfCanApplyStyle++;
                    }
                }

                if (__checkIfCanApplyStyle == 4)
                {
                    keybutton.Font = new Font(cmbFontes.Text, float.Parse(cmbFontSize.Text), __fontStyle);
                    keybutton.TextAlign = (ContentAlignment)__contentAlignment;
                    keybutton.ImageAlign = (ContentAlignment)__contentAlignment;
                    __checkIfCanApplyStyle = 0;
                }
            }

            #endregion

            #region Abrir módulos
            if (btnOpenModuleTextIcons.Tag.Equals("active"))
            {
                KeycapTextIconModule ktm;
                // Precisa botar os que não forem especiais aqui.

                if (keybutton == lblCb13 || keybutton == lblCc13 || keybutton == lblCd13 || keybutton.Name.Contains("Ca") && keybutton != lblCa1
                    && keybutton != lblCa8
                    && keybutton != lblCa9
                    && keybutton != lblCa10
                    && keybutton != lblCa11
                    && keybutton != lblCa12)
                    ktm = new KeycapTextIconModule(false, false, keybutton.Text);

                else if (keybutton.Name.Contains("Ca") || keybutton == lblCb12 || keybutton == lblCc12 || keybutton == lblCd2 || keybutton == lblCd10 || keybutton == lblCd11 || keybutton == lblCd12)
                    ktm = new KeycapTextIconModule(false, true, keybutton.Text);

                else
                    ktm = new KeycapTextIconModule(true, true, keybutton.Text);
                OpenModule(ktm);

                if (ktm.DialogResult == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(ktm.Maintext))
                        keybutton.Text = "";

                    else if (string.IsNullOrWhiteSpace(ktm.Uppertext) && string.IsNullOrWhiteSpace(ktm.Bottomtext))
                        keybutton.Text = ktm.Maintext;

                    else if (string.IsNullOrWhiteSpace(ktm.Bottomtext))
                        keybutton.Text = $"{ktm.Uppertext}\n{ktm.Maintext}";

                    else
                        keybutton.Text = $"{ktm.Uppertext}\n{ktm.Maintext}{ktm.Bottomtext}";
                }

                if (KeycapTextIconModule.HasChosenAIcon)
                {
                    try
                    {
                        int width = keybutton.Width - 5;
                        double razao = (double)keybutton.Width / ktm.SelectedIcon.Width;
                        int height = (int)Math.Round((ktm.SelectedIcon.Height * razao));
                        if (height >= keybutton.Height)
                        {
                            height = keybutton.Height - 5;
                            razao = (double)keybutton.Height / ktm.SelectedIcon.Height;
                            width = (int)Math.Round((ktm.SelectedIcon.Width * razao));
                        }
                        // fiz a variável razão, pois colocar direto não tava dando certo devido ao math.round
                        ImageConverter a = new ImageConverter();
                        Image icon = new Bitmap(ktm.SelectedIcon, width, height);
                        keybutton.Image = icon;
                        keybutton.ImageAlign = ContentAlignment.MiddleCenter;
                    }
                    catch (Exception) { }
                }
            }

            if (btnOpenModuleSwitch.Tag.Equals("active"))
            {
                KeycapSwitchModule ksm = new KeycapSwitchModule(keybutton.Name);
                OpenModule(ksm);
                if (ksm.DialogResult == DialogResult.Yes)
                {
                    //foreach (Control keycap in pnlWithKeycaps.Controls)
                    //{
                    //    if (keycap is Panel && keycap.HasChildren)
                    //    {
                    //        Panel p = new Panel();
                    //        p.Size = new Size(10, 10);
                    //        (new BunifuElipse()).ApplyElipse(p, 7);
                    //        p.BackColor = ksm.SwitchColor;
                    //        p.Location = (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).Location;
                    //        keycap.Controls.Add(p);
                    //        p.Visible = true;
                    //        p.BringToFront();
                    //        //p.MouseMove +=  
                    //    }
                    //}
                }
            }

            if (btnOpenModuleTexture.Tag.Equals("active"))
            {
                KeycapTextureModule ktm = new KeycapTextureModule();
                OpenModule(ktm);
                if (ktm.DialogResult == DialogResult.Cancel)
                {
                    if (keybutton.Size.Equals(new Size(38, 39)))
                        keybutton.Parent.BackgroundImage = Image.FromFile($@"{Application.StartupPath}\Images\Teclas\keycapbackgrounddefault.png");
                    else
                        keybutton.Parent.BackgroundImage = Image.FromFile($@"{Application.StartupPath}\Images\Teclas\{keybutton.Name}.png");
                }

                else if (ktm.DialogResult == DialogResult.OK)
                {
                    foreach (Control keycap in pnlWithKeycaps.Controls)
                    {
                        if (keycap is Panel && keycap.HasChildren)
                        {
                            if ((keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).Size.Equals(new Size(38, 39)))
                                keycap.BackgroundImage = Image.FromFile($@"{Application.StartupPath}\Images\Teclas\keycapbackgrounddefault.png");
                            else
                                keycap.BackgroundImage = Image.FromFile($@"{Application.StartupPath}\Images\Teclas\{(keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).Name}.png");
                        }
                    }
                }

                else if (ktm.DialogResult == DialogResult.No)
                    keybutton.BackgroundImage = ktm.SelectedImg;

                else if (ktm.DialogResult == DialogResult.Yes)
                {
                    foreach (Control keycap in pnlWithKeycaps.Controls)
                    {
                        if (keycap is Panel && keycap.HasChildren)
                        {
                            if (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] is Label)
                                (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).BackgroundImage = ktm.SelectedImg;
                        }
                    }
                }
            }
            #endregion
        }

        #region Método inicializador de módulos

        private void OpenModule(KeycapParentModule kpm)
        {
            GenerateDarkScreenshot();
            kpm.StartPosition = FormStartPosition.CenterScreen;
            kpm.ShowDialog(this);
            if (kpm.DialogResult == DialogResult.OK || kpm.DialogResult == DialogResult.Cancel || kpm.DialogResult == DialogResult.Yes || kpm.DialogResult == DialogResult.No)
                DisposePanel();
        }

        private void OpenSwitchDialog(Label LabelThatHasASwitch, Bitmap SwitchPicture)
        {
            Panel SwitchDialog = new Panel();
            SwitchDialog.Size = new Size(350, 100);
            (new BunifuElipse()).ApplyElipse(SwitchDialog, 10);
            SwitchDialog.BackColor = Color.FromArgb(45, 46, 47);
            SwitchDialog.Location = new Point(LabelThatHasASwitch.Location.X + 25, LabelThatHasASwitch.Location.Y + 25);
            this.Controls.Add(SwitchDialog);
            SwitchDialog.Visible = true;
            SwitchDialog.BringToFront();

            PictureBox pb = new PictureBox();


        }


        #endregion

        #endregion

        #region Métodos do darken form

        private Panel darkenPanel;
        // Tira uma screenshot do formulário e escurece-a.
        private void GenerateDarkScreenshot()
        {
            darkenPanel = new Panel();
            Bitmap bmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                G.CopyFromScreen(this.PointToScreen(new Point(0, 0)), new Point(0, 0), this.ClientRectangle.Size);
                double percent = 0.75;
                Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
                using (Brush brsh = new SolidBrush(darken))
                {
                    G.FillRectangle(brsh, this.ClientRectangle);
                }
            }

            darkenPanel.Location = new Point(0, 0);
            darkenPanel.Size = this.ClientRectangle.Size;
            darkenPanel.BackgroundImage = bmp;
            this.Controls.Add(darkenPanel);
            darkenPanel.BringToFront();
        }

        private void DisposePanel() => darkenPanel.Dispose();

        #endregion

        #region btnVoltar
        //Ao clicar no botão de fechar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (Share.EditKeyboard)
                ExportToWebSite();
            Share.Collection = new Collection();
            Share.EditKeyboard = false;
            this.Close();
            SelectKeyboard __selectKeyboard = new SelectKeyboard();
            __selectKeyboard.ShowDialog();

        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            btnVoltar.Font = new Font(btnVoltar.Font, FontStyle.Underline | FontStyle.Bold);
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            btnVoltar.Font = new Font(btnVoltar.Font, FontStyle.Bold);
        }
        #endregion

        #region Construtor
        public Compacto()
        {
            BunifuElipse e = new BunifuElipse();
            InitializeComponent();
            foreach (Control c in pnlWithKeycaps.Controls)
                if (c is Panel)
                {
                    e.ApplyElipse(c, 5);
                    foreach (Control d in c.Controls)
                        if (d is Label)
                            e.ApplyElipse(d, 3);
                }
            e.ApplyElipse(picBoxKeyboardBackground, 20);

            //Eu preciso disso no construtor, sorry. Não dá pra colocar dois estilos na Open Sans logo no designer.

            btnStyleUnderline.Font = new Font(btnStyleUnderline.Font, FontStyle.Underline);
            btnStyleStrikeout.Font = new Font(btnStyleStrikeout.Font, FontStyle.Strikeout);

            //Arredondando o botão de cor de fonte:

            Bunifu.Framework.UI.BunifuElipse be = new Bunifu.Framework.UI.BunifuElipse();
            be.ApplyElipse(pnlBtnStyleFontColor, 5);

            //Foreach para arredondar cores do colorpicker
            foreach (Control c in pnlBodyColorpicker.Controls)
            {
                if (c is Button)
                {
                    Bunifu.Framework.UI.BunifuElipse elipse = new Bunifu.Framework.UI.BunifuElipse();
                    elipse.ApplyElipse(c, 5);
                }
            }

            if (Share.EditKeyboard)
            {
                //Fazendo com que o label do nome do teclado tenha localização exatamente após o label que contém o nome da coleção.
                AtualizarLabels();
                LoadKeyboard();
            }
            else
            {
                //if (!Share.User.isPremiumAccount)

                //    if (Share.User.KeyboardQuantity == 5)
                //    {
                //        AcroniMessageBoxConfirm mb = new AcroniMessageBoxConfirm("Sinto muito, mas você atingiu o limite de teclados que você " +
                //                        "pode criar usando essa conta.", "Atualize sua conta agora mesmo para uma conta Premium");
                //        mb.ShowDialog();
                //    }

                lblCollectionName.Visible = false;
                lblKeyboardName.Location = lblCollectionName.Location;
                lblKeyboardName.Text = "Sem Nome";
                lblCollectionName.Text = "";
            }
        }

        #endregion

        #region Métodos do Color Picker

        private bool[] __IsSlotAvailable { get; set; } = { true, false, false, false };

        //Clicks que ocorrem ao selecionar uma cor
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (btnOpenModuleTextIcons.Tag.Equals("active"))
            {
                btnOpenModuleTextIcons.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleTextIcons.Tag = "disable";
            }
            else if (btnOpenModuleTexture.Tag.Equals("active"))
            {
                btnOpenModuleTexture.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleTexture.Tag = "disable";
            }
            else if (btnOpenModuleSwitch.Tag.Equals("active"))
            {
                btnOpenModuleSwitch.BackColor = Color.FromArgb(31, 32, 34);
                btnOpenModuleSwitch.Tag = "disable";
            }
            Button b = (Button)sender;
            lblHexaColor.Text = $"#{b.BackColor.R.ToString("X2")}{b.BackColor.G.ToString("X2")}{b.BackColor.B.ToString("X2")}";

            if (btnStyleFontColor.Tag.Equals("active"))
                FontColor = b.BackColor;

            if (b.Tag.ToString().Contains("Ambar"))
                lblColorName.Text = "Âmbar";
            else if (b.Tag.ToString().Contains("_"))
                lblColorName.Text = b.Name.Replace("_", " ");
            else if (b.Tag.ToString().Contains("Preto"))
                lblColorName.Text = "Preto (cor padrão)";
            else
                lblColorName.Text = b.Name;

            //--Transição para mudar de cor
            Transition transition = new Transition(new TransitionType_EaseInEaseOut(200));
            transition.add(pnlChosenColor, "BackColor", b.BackColor);
            transition.run();

            //Define a cor da tecla no kbtn_Click. 
            if (!btnStyleFontColor.Tag.Equals("active"))
                Color = b.BackColor;

            if (__IsSlotAvailable[0])
            {
                btnHist1.Tag = b.Tag;
                lblColorName.Text = btnHist1.Tag.ToString();
                btnHist1.Visible = true;
                btnHist1.BackColor = b.BackColor;
                __IsSlotAvailable[0] = false;
                __IsSlotAvailable[1] = true;
            }

            else if (__IsSlotAvailable[1])
            {
                btnHist2.Tag = b.Tag;
                lblColorName.Text = btnHist2.Tag.ToString();
                btnHist2.Visible = true;
                btnHist2.BackColor = b.BackColor;
                __IsSlotAvailable[1] = false;
                __IsSlotAvailable[2] = true;
            }

            else if (__IsSlotAvailable[2])
            {
                btnHist3.Tag = b.Tag;
                lblColorName.Text = btnHist3.Tag.ToString();
                btnHist3.Visible = true;
                btnHist3.BackColor = b.BackColor;
                __IsSlotAvailable[2] = false;
                __IsSlotAvailable[3] = true;
            }

            else if (__IsSlotAvailable[3])
            {
                btnHist4.Tag = b.Tag;
                lblColorName.Text = btnHist4.Tag.ToString();
                btnHist4.Visible = true;
                btnHist4.BackColor = b.BackColor;
                __IsSlotAvailable[3] = false;
                __IsSlotAvailable[0] = true;
            }
        }

        private void ChangeColorFundoKbtn(object sender, PaintEventArgs e)
        {
            try
            {
                if (!keybutton.BackColor.Equals(Color.FromArgb(26, 26, 26)))
                {
                    Controls.Find("fundo" + keybutton.Name, true)[0].BackColor = Color.FromArgb(90, keybutton.BackColor);
                }
            }
            catch (Exception) { }
        }

        #region Hover para cada uma das cores do colorpicker


        private void btnColor_MouseLeave(object sender, EventArgs e)
        {
            Button btnColor = (Button)sender;
            btnColor.Size = new Size(btnColor.Size.Width - 5, btnColor.Size.Height - 5);
            btnColor.Location = new Point(btnColor.Location.X + (5 / 2), btnColor.Location.Y + (5 / 2));
            Bunifu.Framework.UI.BunifuElipse bunifuElipse = new Bunifu.Framework.UI.BunifuElipse();
            bunifuElipse.ApplyElipse(btnColor, 5);
        }

        private void btnColor_MouseEnter(object sender, EventArgs e)
        {
            Button btnColor = (Button)sender;
            btnColor.Size = new Size(btnColor.Size.Width + 5, btnColor.Size.Height + 5);
            btnColor.Location = new Point(btnColor.Location.X - (5 / 2), btnColor.Location.Y - (5 / 2));
            Bunifu.Framework.UI.BunifuElipse bunifuElipse = new Bunifu.Framework.UI.BunifuElipse();
            bunifuElipse.ApplyElipse(btnColor, 5);
        }

        #endregion

        #endregion

        #region Fontes das teclas e texto

        private void FormLoad(object sender, EventArgs e)
        {
            FadeIn();

            //Carregar todas as fontes que o usuário possui na máquina
            new LoadFontTypes(ref cmbFontes, ref lista_fontFamily);

            //Index padrão da combobox
            cmbFontes.SelectedIndex = cmbFontes.Items.IndexOf("Open Sans");
            cmbFontSize.SelectedIndex = 1;
        }

        private void lblDefinirParaTodasTeclas_Click(object sender, EventArgs e)
        {
            AcroniMessageBoxConfirm ambc = new AcroniMessageBoxConfirm("Você tem certeza disso?", "Atenção, editar e pintar para todas as teclas poderá fazer você" +
                " perder todas as edições que fez até agora. Vai tudo ficar padrãozinho.");

            if (ambc.ShowDialog() == DialogResult.Yes)
            {
                foreach (Control keycap in pnlWithKeycaps.Controls)
                {
                    if (keycap is Panel && keycap.HasChildren)
                    {
                        if (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] is Label)
                        {
                            (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).BackColor = Color;
                            (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).Font = new Font(cmbFontes.Text, float.Parse(cmbFontSize.Text), __fontStyle);
                            (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).TextAlign = (ContentAlignment)__contentAlignment;

                            if (Color != Color.FromArgb(26, 26, 26))
                            {
                                if ((keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label) == lblCb14sExtensao || (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label) == lblCb14s)
                                {
                                    lblCb14s.Parent.BackgroundImage = null;
                                    lblCb14sExtensao.Parent.BackgroundImage = null;

                                    if ((keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label) == lblCb14s)
                                    {
                                        lblCb14sExtensao.BackColor = Color;
                                        lblCb14sExtensao.Parent.BackColor = Color.FromArgb(90, (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).BackColor);
                                    }
                                    else
                                    {
                                        lblCb14s.BackColor = Color;
                                        lblCb14s.Parent.BackColor = Color.FromArgb(90, (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).BackColor);
                                    }
                                }

                                else
                                {
                                    keycap.BackgroundImage = null;
                                    keycap.BackColor = Color.FromArgb(90, (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).BackColor);
                                }

                                keycap.BackgroundImage = null;
                                keycap.BackColor = Color.FromArgb(90, (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).BackColor);
                            }

                            else
                            {
                                if ((keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).Size.Equals(new Size(38, 39)))
                                    keycap.BackgroundImage = Image.FromFile($@"{Application.StartupPath}\Images\Teclas\keycapbackgrounddefault.png");
                                else
                                {
                                    keycap.BackColor = Color.Black;
                                    keycap.BackgroundImage = Image.FromFile($@"{Application.StartupPath}\Images\Teclas\{(keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).Name}.png");
                                }

                            }
                            if (btnStyleFontColor.Tag.Equals("active"))
                                (keycap.Controls[keycap.Name.Replace("fundo", "lbl")] as Label).ForeColor = FontColor;
                        }
                    }
                }
            }
        }

        #endregion

        #region Controladores dos módulos e das cores dos botões de módulo.


        private void ApplyColorToModuleButton(Control c, bool isDeactivationNecessary)
        {
            if (isDeactivationNecessary == true || c != btnStyleFontColor)
            {
                foreach (Control btnOpenModule in pnlBtnOpenModules.Controls)
                {
                    if (!btnOpenModule.Tag.Equals("active"))
                    {
                        if (btnOpenModule != c)
                        {
                            btnOpenModule.BackColor = Color.FromArgb(31, 32, 34);
                            btnOpenModule.Tag = "disable";
                        }
                        else
                        {
                            btnOpenModule.BackColor = Color.FromArgb(80, 80, 80);
                            btnOpenModule.Tag = "active";
                        }
                    }
                    else
                    {
                        btnOpenModule.BackColor = Color.FromArgb(31, 32, 34);
                        btnOpenModule.Tag = "disable";
                    }
                }
            }
            else
            {
                if (!c.Tag.Equals("active"))
                {
                    c.BackColor = Color.FromArgb(80, 80, 80);
                    c.Tag = "active";
                }
                else
                {
                    c.BackColor = Color.FromArgb(31, 32, 34);
                    c.Tag = "disable";
                }
            }
        }

        private void btnOpenModuleSwitch_Click(object sender, EventArgs e)
        {
            ApplyColorToModuleButton(btnOpenModuleSwitch, true);
        }

        private void btnStyleFontColor_Click(object sender, EventArgs e)
        {
            ApplyColorToModuleButton(btnStyleFontColor, false);
        }

        private void btnTextAndIcons_Click(object sender, EventArgs e)
        {
            ApplyColorToModuleButton(btnOpenModuleTextIcons, true);
        }

        private void btnOpenModuleBackground_Click(object sender, EventArgs e)
        {
            KeycapBackgroundModule kbm = new KeycapBackgroundModule();
            OpenModule(kbm);
            if (kbm.DialogResult == DialogResult.Yes)
                picBoxKeyboardBackground.Image = kbm.SelectedImg;
        }

        private void btnOpenModuleTexture_Click(object sender, EventArgs e)
        {
            ApplyColorToModuleButton(btnOpenModuleTexture, true);
        }

        #endregion

        #region Carregar e salvar teclado

        private void AtualizarLabels()
        {
            lblKeyboardName.Text = Share.Keyboard.NickName;
            lblCollectionName.Text = Share.Collection.CollectionName + " • ";
            lblCollectionName.Visible = true;
            lblKeyboardName.Visible = true;
            lblKeyboardName.Location = new Point(lblCollectionName.Location.X + lblCollectionName.Width - 6, lblCollectionName.Location.Y);
        }

        private void LoadKeyboard()
        {
            bool addedEnterYet = false;
            picBoxKeyboardBackground.Image = Share.Keyboard.BackgroundImage;
            picBoxKeyboardBackground.SizeMode = (PictureBoxSizeMode)Share.Keyboard.BackgroundModeSize;
            picBoxKeyboardBackground.BackColor = Share.Keyboard.BackgroundColor;

            foreach (Control keycap in pnlWithKeycaps.Controls)
            {
                if (keycap.Name.Contains("fundo"))
                {
                    foreach (Keycap k in Share.Keyboard.Keycaps)
                    {
                        if (("lbl" + keycap.Name.Remove(0, 5)).Equals(k.ID))
                        {
                            try
                            {
                                foreach (Control c in keycap.Controls)
                                {
                                    if (c.Name.Contains("lbl"))
                                    {
                                        c.ForeColor = k.ForeColor;
                                        (c as Label).Image = k.Icon;
                                        c.Font = k.Font;
                                        c.Text = k.Text;
                                        c.BackColor = k.Color;
                                        if (!c.BackColor.Equals(Color.FromArgb(26, 26, 26)))
                                        {
                                            if (addedEnterYet)
                                                paintedKeycapsCounter++;
                                            if (c.Name.Equals(lblCa14s.Name))
                                                addedEnterYet = true;
                                            c.Parent.BackColor = Color.FromArgb(90, k.Color);
                                            c.Parent.BackgroundImage = null;
                                        }
                                        (c as Label).TextAlign = (ContentAlignment)k.ContentAlignment;
                                    }
                                }
                                //keycap.Text = k.Text;


                                break;
                            }
                            catch (Exception e) { MessageBox.Show(e.Message); }
                        }
                    }
                }
            }
            lblPaintedKeycaps.Text = paintedKeycapsCounter + "";
        }



        //private void btnLer_Click(object sender, EventArgs e)
        //{
        //    using (FileStream openarchive = new FileStream(Application.StartupPath + @"\" + SQLConnection.nome_usuario + ".acr", FileMode.Open))
        //    {
        //        BinaryFormatter ofByteArrayToObject = new BinaryFormatter();
        //        collection = (Collection)ofByteArrayToObject.Deserialize(openarchive);
        //    }

        //    picBoxKeyboardBackground.Image = collection.Keyboards[0].BackgroundImage;

        //    picBoxKeyboardBackground.SizeMode = (PictureBoxSizeMode)collection.Keyboards[0].BackgroundModeSize;

        //    foreach (Control control in this.Controls)
        //    {
        //        if (control is Kbtn)
        //        {
        //            foreach (Keycap tecla in this.collection.Keyboards[0].Keycaps)
        //            {
        //                if (control.Name.Equals(tecla.ID))
        //                {
        //                    control.Name = tecla.ID;
        //                    control.Font = tecla.Font;
        //                    control.BackColor = tecla.Color;
        //                    control.Text = tecla.Text;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //}
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            bool canSave = false;
            if (!Share.User.isPremiumAccount)
                if (!Share.EditKeyboard)
                {
                    if (Share.User.KeyboardQuantity == 5)
                    {
                        AcroniMessageBoxConfirm mb = new AcroniMessageBoxConfirm("Sinto muito, mas você atingiu o limite de teclados que você " +
                                        "pode criar usando essa conta.", "Atualize sua conta agora mesmo para uma conta Premium");
                        mb.ShowDialog();
                    }
                    else
                    {
                        canSave = true;
                    }
                }
                else
                {
                    canSave = true;
                }
            else
                canSave = true;
            if (canSave)
            {
                if (!Share.EditKeyboard)
                {
                    AcroniMessageBoxInput keyboardName = new AcroniMessageBoxInput("Insira o nome de seu teclado");
                    keyboardName.ShowDialog();
                    while (keyboardName.Visible)
                    {
                        await Task.Delay(100);
                    }
                }
                SaveKeyboard();
            }
        }

        private async void SaveKeyboard()
        {
            if (!Share.EditKeyboard)
            {
                if (!String.IsNullOrEmpty(Share.KeyboardNameNotCreated))
                {
                    AcroniMessageBoxConfirm mb = new AcroniMessageBoxConfirm("Agora, aparecerá sua galeria.", "Nela, clique na coleção que deseja salvar seu teclado ^-^");
                    if (mb.ShowDialog() != DialogResult.Cancel)
                    {
                        Galeria selectGallery = new Galeria(true);
                        selectGallery.Show();

                        while (selectGallery.Visible)
                        {
                            await Task.Delay(10);
                        }

                        if (!String.IsNullOrEmpty(Share.Collection.CollectionName))
                        {
                            setPropriedadesTeclado();
                            SQLProcMethods.UPDATE_QtdeTeclados();
                        }
                    }
                }
            }

            else
            {
                foreach (Collection col in Share.User.UserCollections)
                {
                    if (Share.Collection.CollectionName.Equals(col.CollectionName))
                    {
                        col.Keyboards.Remove(Share.Keyboard);
                        setPropriedadesTeclado();
                        break;
                    }
                }
            }

            if ((!String.IsNullOrEmpty(Share.Collection.CollectionName) && !String.IsNullOrEmpty(Share.KeyboardNameNotCreated)) || Share.EditKeyboard)
            {
                AtualizarLabels();
                ++Share.User.KeyboardQuantity;
                AcroniMessageBoxConfirm success = new AcroniMessageBoxConfirm("Teclado adicionado/salvo com sucesso!", "Ele se encontrará na coleção selecionada, em sua galeria :D");
                success.ShowDialog();
                Share.EditKeyboard = true;
                Share.Keyboard = keyboard;
                Share.User.SendToFile();
                ExportToWebSite();
            }
            else
            {
                AcroniMessageBoxConfirm fail = new AcroniMessageBoxConfirm("Tu cancelastes a operação no meio do processo/Salvamento inválido ;-;", "Tente novamente, se desejas mesmo salvá - lo!");
                fail.ShowDialog();
            }
        }

        private void setPropriedadesTeclado()
        {
            keyboard.Name = "Acroni-Compacto";
            keyboard.ID = KeyboardIDGenerator.GenerateID('C');
            if (!Share.EditKeyboard)
                keyboard.NickName = Share.KeyboardNameNotCreated;
            else
                keyboard.NickName = Share.Keyboard.NickName;
            keyboard.KeyboardType = this.Name.Substring(7);
            keyboard.BackgroundImage = picBoxKeyboardBackground.Image;
            keyboard.BackgroundColor = picBoxKeyboardBackground.BackColor;
            keyboard.BackgroundModeSize = picBoxKeyboardBackground.SizeMode;
            keyboard.KeyboardImage = Screenshot.TakeSnapshot(picBoxKeyboardBackground,pnlWithKeycaps) ;
            string text = "";
            Color backcolor = Color.Empty;
            Color forecolor = Color.Empty;
            Font font = null;
            Image image = null;
            object textalign = ContentAlignment.TopLeft;
            string name = "";
            short switch1 = 0;
            foreach (Control tecla in pnlWithKeycaps.Controls)
                if (tecla.Name.Contains("fundo"))
                {
                    {
                        foreach (Control c in tecla.Controls)
                        {
                            foreach (Keycap k in Share.Keyboard.Keycaps)
                                if (k.ID.Equals(c.Name))
                                    switch1 = k.Switch;
                            if (c.Name.Contains("lbl"))
                            {
                                image = (c as Label).Image;
                                text = c.Text;
                                forecolor = c.ForeColor;
                                font = c.Font;
                                backcolor = c.BackColor;
                                name = c.Name;
                                textalign = (c as Label).TextAlign;
                            }


                        }
                        keyboard.Keycaps.Add(new Keycap
                        {
                            Switch = switch1,
                            ForeColor = forecolor,
                            ID = name,
                            Text = text,
                            Font = font,
                            Color = backcolor,
                            ContentAlignment = textalign,
                            Icon = image
                        });
                    }
                }

            foreach (Collection col in Share.User.UserCollections)
            {
                int i = 0;
                if (col.CollectionName.Equals(Share.Collection.CollectionName))
                {
                    col.Keyboards.Add(keyboard);
                    col.CollectionID = i + 1;
                    break;
                }
            }

            //using (FileStream savearchive = new FileStream($@"{Application.StartupPath}\..\..\{SQLConnection.nome_usuario}.acr", FileMode.OpenOrCreate))
            //{
            //    BinaryFormatter Serializer = new BinaryFormatter();
            //    Serializer.Serialize(savearchive, Share.User);
            //}
        }

        #endregion

        #region Exportar pro site
        private void ExportToWebSite()
        {
            bool alreadyExistsThisKeyboard = false;
            byte[]img = (Byte[])new ImageConverter().ConvertTo(Screenshot.TakeSnapshot(pnlWithKeycaps,picBoxKeyboardBackground) , typeof(Byte[]));

            try
            {
                DataTable return_value = SQLProcMethods.SELECT_NicknameTelcadoFrom(Share.User.ID);
                if (return_value.Rows.Count != 0)
                {
                    foreach (DataRow value in return_value.Rows)
                    {
                        if (value[0].ToString().Equals(Share.Keyboard.NickName))
                        {
                            alreadyExistsThisKeyboard = true;
                            break;
                        }
                    }
                }
                if (!alreadyExistsThisKeyboard)
                    SQLProcMethods.INSERT_TecladoCustomizado(Share.User.ID, img, Share.Collection.CollectionName, Share.Keyboard.NickName, 250.00);
                else
                    SQLProcMethods.UPDATE_ImgTecladoCustomizado(img, Share.User.ID, Share.Keyboard.NickName);
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Cliques que são usados para cancelar ações de outros botões

        private void picBoxKeyboardBackground_Click(object sender, EventArgs e)
        {
            picBoxKeyboardBackground.BackColor = Color;
            base.generalClickCancel(sender, e);
        }

        private void pnlCustomizingMenu_Click(object sender, EventArgs e)
        {
            base.generalClickCancel(sender, e);
        }

        private void generalClicks(object sender, EventArgs e)
        {
            base.generalClickCancel(sender, e);
        }

        #endregion

    }
}
