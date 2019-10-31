using AcroniControls;
using AcroniLibrary.FileInfo;
using AcroniLibrary.SQL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AcroniUI.Custom.CustomModules
{
    public partial class KeycapBackgroundModule : KeycapParentModule
    {

        Bunifu.Framework.UI.BunifuElipse e = new Bunifu.Framework.UI.BunifuElipse();

        public KeycapBackgroundModule()
        {
            InitializeComponent();

            foreach (Control c in this.Controls)
            {
                e.ApplyElipse(c, 5);
            }

            if (File.Exists($@"{Application.StartupPath}\UserImageIcons\{SQLConnection.nome_usuario}IconsHistoric.hist"))
            {
                using (FileStream openarchive = new FileStream($@"{Application.StartupPath}\UserImageIcons\{SQLConnection.nome_usuario}IconsHistoric.hist", FileMode.Open))
                {
                    try
                    {
                        BinaryFormatter fromByteArrayToObject = new BinaryFormatter();
                        List<KeyboardIcons> __currentList = (List<KeyboardIcons>)fromByteArrayToObject.Deserialize(openarchive);

                        for (int i = 0; i < __currentList.Count; i++)
                        {
                            (pnlImages.Controls[$"pnlImg{i + 1}"].Controls[$"picBoxImg{i + 1}"] as PictureBox).Image = __currentList[i].UserIcon;
                            (pnlImages.Controls[$"pnlImg{i + 1}"].Controls[$"picBoxImg{i + 1}"] as PictureBox).SizeMode = PictureBoxSizeMode.Zoom;
                            (pnlImages.Controls[$"pnlImg{i + 1}"] as Panel).Visible = true;
                            (pnlImages.Controls[$"pnlImg{i + 1}"] as Panel).BackColor = Color.FromArgb(80, 80, 80);
                            (pnlImages.Controls[$"pnlImg{i + 1}"].Controls[$"lblPic{i + 1}"] as Label).Text = __currentList[i].UserDefinedIconName;
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception("Arquivo não encontrado. ");
                    }
                }
            }
        }

        //Declaração das propriedades dos ícones
        private Queue<Image> ImageQueue = new Queue<Image>();

        public Image SelectedImg { get; set; }

        public static bool HasChosenAnImg { get; set; }

        private Queue<String> __imageName = new Queue<String>();

        private void btnNewIcon_Click(object sender, EventArgs e)
        {

            List<KeyboardIcons> insertableArray = new List<KeyboardIcons>();

            using (OpenFileDialog iconGetter = new OpenFileDialog())
            {
                iconGetter.InitialDirectory = @"C:\";
                iconGetter.Title = "Qual o ícone que deseja adicionar?";
                iconGetter.Filter = "Todos os tipos de imagem | *jpg; *.jpeg; *.bmp; *.png; *.ico|BMP | *.bmp | JPG | *.jpg; *.jpeg | PNG | *.png | ICO | *.ico | Todos| *.*";
                iconGetter.Multiselect = true;
                if (iconGetter.ShowDialog() == DialogResult.OK)
                {
                    foreach (String fileDirectory in iconGetter.FileNames)
                    {
                        ImageQueue.Enqueue(Image.FromFile(fileDirectory));
                    }

                    while (ImageQueue.Count > 10)
                    {
                        ImageQueue.Dequeue();
                        __imageName.Dequeue();
                    }

                    AcroniMessageBoxInput input = new AcroniMessageBoxInput("Muito legal a imagem, parabéns.", "Agora escolha um nome para ela.");
                    if (input.ShowDialog() == DialogResult.OK)
                        __imageName.Enqueue(input.input);
                    else
                    {
                        ImageQueue = new Queue<Image>(ImageQueue.Reverse());
                        ImageQueue.Dequeue();
                    }
                }

                for (int aux = ImageQueue.Count - 1; aux >= 0; aux--)
                {
                    insertableArray.Add(new KeyboardIcons()
                    {
                        UserIcon = ImageQueue.ToArray()[aux],
                        UserDefinedIconName = __imageName.ToArray()[aux]
                    });
                }
            }

            for (int i = 0; i < ImageQueue.Count; i++)
            {
                //É um array composto por uma imagem (ícone) junto com seu nome: 

                (pnlImages.Controls[$"pnlImg{i + 1}"].Controls[$"picBoxImg{i + 1}"] as PictureBox).Image = insertableArray[i].UserIcon;
                (pnlImages.Controls[$"pnlImg{i + 1}"].Controls[$"picBoxImg{i + 1}"] as PictureBox).SizeMode = PictureBoxSizeMode.Zoom;
                (pnlImages.Controls[$"pnlImg{i + 1}"] as Panel).Visible = true;
                (pnlImages.Controls[$"pnlImg{i + 1}"] as Panel).BackColor = Color.FromArgb(80, 80, 80);
                (pnlImages.Controls[$"pnlImg{i + 1}"].Controls[$"lblPic{i + 1}"] as Label).Text = insertableArray[i].UserDefinedIconName;

                using (FileStream savearchive = new FileStream($@"{Application.StartupPath}\UserImageIcons\{SQLConnection.nome_usuario}IconsHistoric.hist", FileMode.Create))
                {
                    BinaryFormatter Serializer = new BinaryFormatter();
                    Serializer.Serialize(savearchive, insertableArray);
                }
            }
        }

        private void picIcons_Click(object sender, EventArgs e)
        {
            PictureBox icon = (PictureBox)sender;

            if (sender != null)
            {
                if (icon.Tag.Equals("Chosen"))
                {
                    icon.Tag = "Not chosen";
                    pnlBtnIconChosen.Visible = false;
                    SelectedImg = global::AcroniUI.Properties.Resources.compacto;
                    HasChosenAnImg = false;
                }
                else
                {
                    icon.Tag = "Chosen";
                    icon.Parent.Controls.Add(pnlBtnIconChosen);
                    pnlBtnIconChosen.Visible = true;
                    pnlBtnIconChosen.Location = new Point(icon.Location.X + icon.Size.Width - 10, icon.Location.Y + icon.Size.Height - 10);
                    pnlBtnIconChosen.BringToFront();
                    SelectedImg = icon.Image;
                    HasChosenAnImg = true;
                }
            }
        }

        protected virtual void btnExcludeBackgroundImage_Click(object sender, EventArgs e)
        {
            SelectedImg = null;
        }
    }
}
