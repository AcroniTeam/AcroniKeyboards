using AcroniControls;
using AcroniLibrary.FileInfo;
using AcroniUI.Custom;
using AcroniLibrary.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcroniUI
{
    public partial class CollectionSelected : TemplateMenu
    {
        private int contKeyboards = 0;   
        public CollectionSelected()
        {
            InitializeComponent();
            Share.User.CatchFromFile();
            pnlWithKeyboards.AutoScroll = true;
            loadKeyboards();
            lblCollectionName.Text = Share.Collection.CollectionName;
            lblKeyboardsNumber.Text = contKeyboards + " "+lblKeyboardsNumber.Text;
        }
        
        private void loadKeyboards()
        {
            int countLateralPadding = 0;
            int countUpBottomPadding = 0;
            bool canCountLateralPadding = true;
            foreach(Collection col in Share.User.UserCollections)
                if(Share.Collection.CollectionName.Equals(col.CollectionName))
            foreach (Keyboard userKeyboard in col.Keyboards)
            {
                Share.Keyboard = userKeyboard;           
                Keyboard_CollectionSelected userKeyboardUI = new Keyboard_CollectionSelected();                         
                userKeyboardUI.Location = new Point(countLateralPadding, countUpBottomPadding);
                if (countLateralPadding == 468)
                {
                    countLateralPadding = 0;
                    countUpBottomPadding += 238;
                    canCountLateralPadding = false;
                }
                if(canCountLateralPadding)
                countLateralPadding += 234;
                foreach (Control c in userKeyboardUI.Controls)
                {
                    if (c.Name.Equals("picBoxDeleteIcon"))
                        c.Click += new EventHandler(DeleteKeyboard);
                    else if (c.Name.Equals("picBoxPreviewKeyboard") || c.Name.Equals("lblKeyboardType") || c.Name.Equals("lblKeyboardName"))
                    {
                        c.Click += new EventHandler(OpenKeyboard);
                        c.MouseEnter += new EventHandler(MouseEnter);
                    }

                }
                userKeyboardUI.MouseEnter += new EventHandler(MouseEnter);
                userKeyboardUI.MouseLeave += new EventHandler(MouseLeave);
                pnlWithKeyboards.Controls.Add(userKeyboardUI);
                contKeyboards++;
                canCountLateralPadding = true;         
            }
        }
        private void OpenKeyboard(object sender, EventArgs e)
        {
            Panel parent;
            if ((sender as Control).Parent.Name.Equals("pnlWithKeyboards"))
                parent = (Panel)sender;
            else
                parent = (Panel)(sender as Control).Parent;
            foreach (Collection userCollection in Share.User.UserCollections)
                if (userCollection.CollectionName.Equals(lblCollectionName.Text))
                    foreach (Keyboard userKeyboard in userCollection.Keyboards)
                        if (userKeyboard.ID.Equals(parent.Name))
                        {
                            Share.Keyboard = userKeyboard;
                            Share.EditKeyboard = true;
                            Form editKeyboard = null;
                            if (userKeyboard.KeyboardType.Equals("Compacto"))
                                editKeyboard = new Compacto();
                            else if (userKeyboard.KeyboardType.Equals("Tenkeyless"))
                                editKeyboard = new Tenkeyless();
                            else if (userKeyboard.KeyboardType.Equals(("FullSize")))
                                editKeyboard = new Fullsize();
                            editKeyboard.Show();
                            this.Close();
                        }

        }    
        private void DeleteKeyboard(object sender, EventArgs e)
        {
            AcroniMessageBoxConfirm confirmExclude = new AcroniMessageBoxConfirm("Deseja mesmo excluir este teclado?", "Não terá como reverter o processo O_O");
            if (confirmExclude.ShowDialog() == DialogResult.Yes)
            {
                foreach (Collection userCollection in Share.User.UserCollections)
                    if (userCollection.CollectionName.Equals(lblCollectionName.Text))
                        foreach (Keyboard userKeyboard in userCollection.Keyboards)
                            if (userKeyboard.ID.Equals((sender as PictureBox).Parent.Name))
                            {
                                SQLProcMethods.DELETE_TecladoCustomizadoFromName(Share.User.ID, userKeyboard.NickName);
                                userCollection.Keyboards.Remove(userKeyboard);
                                Share.User.KeyboardQuantity--;
                                Share.User.SendToFile();
                                CollectionSelected recharge = new CollectionSelected();
                                recharge.Show();
                                this.Close();
                                break;

                            }
            }
        }
        Color controlkeyboardcolor = Color.FromArgb(35, 36, 40);
        private new void MouseEnter(object sender, EventArgs e)
        {
            Panel father;
            if (!(sender as Control).Parent.Name.Equals("pnlWithKeycaps"))
                father = (Panel)(sender as Control).Parent;
            else
                father = (Panel)(sender as Control);
            father.BackColor = Color.FromArgb(30,30,30);
            pnlWithKeyboards.BackColor = Color.Transparent;
        }
        private new void MouseLeave(object sender, EventArgs e)
        {
            (sender as Control).BackColor = controlkeyboardcolor;
            pnlWithKeyboards.BackColor = Color.Transparent;
        }
    }
}
