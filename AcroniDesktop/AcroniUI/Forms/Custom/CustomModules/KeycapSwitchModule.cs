using AcroniControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using AcroniLibrary.FileInfo;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcroniUI.Custom.CustomModules
{
    public partial class KeycapSwitchModule : KeycapParentModule
    {
        public short chosenSwitch;
        private string keybuttonName;
        private void VerifySwitch()
        {
            short Switch = 0;
            foreach (Keycap c in Share.Keyboard.Keycaps)
                if (c.ID.Equals(keybuttonName))
                    Switch = c.Switch;
            switch (Switch)
            {
                case 1:

                    picswitch1.Tag = "Chosen";
                    pnlBtnIconChosen.Visible = true;
                    pnlBtnIconChosen.Location = new Point(picswitch1.Location.X + picswitch1.Size.Width - 10, picswitch1.Location.Y + picswitch1.Size.Height - 10);
                    pnlBtnIconChosen.BringToFront();
                    break;
                case 2:
                    picswitch2.Tag = "Chosen";
                    pnlBtnIconChosen.Visible = true;
                    pnlBtnIconChosen.Location = new Point(picswitch2.Location.X + picswitch2.Size.Width - 10, picswitch2.Location.Y + picswitch2.Size.Height - 10);
                    pnlBtnIconChosen.BringToFront();
                    break;
                case 3:
                    picswitch3.Tag = "Chosen";
                    pnlBtnIconChosen.Visible = true;
                    pnlBtnIconChosen.Location = new Point(picswitch3.Location.X + picswitch3.Size.Width - 10, picswitch3.Location.Y + picswitch3.Size.Height - 10);
                    pnlBtnIconChosen.BringToFront();
                    break;
                case 4:
                    picswitch4.Tag = "Chosen";
                    pnlBtnIconChosen.Visible = true;
                    pnlBtnIconChosen.Location = new Point(picswitch4.Location.X + picswitch4.Size.Width - 10, picswitch4.Location.Y + picswitch4.Size.Height - 10);
                    pnlBtnIconChosen.BringToFront();
                    break;
                case 5:
                    picswitch5.Tag = "Chosen";
                    pnlBtnIconChosen.Visible = true;
                    pnlBtnIconChosen.Location = new Point(picswitch5.Location.X + picswitch5.Size.Width - 10, picswitch5.Location.Y + picswitch5.Size.Height - 10);
                    pnlBtnIconChosen.BringToFront();
                    break;

            }
        }
        public KeycapSwitchModule(string keybuttonName)
        {
            InitializeComponent();
            this.keybuttonName = keybuttonName;
            VerifySwitch();
            Bunifu.Framework.UI.BunifuElipse e = new Bunifu.Framework.UI.BunifuElipse();
            foreach (Control c in this.Controls)
            {
                if (!(c is Label))
                {
                    e.ApplyElipse(c, 5);
                }
            }
        }

        public Color SwitchColor { get; set; }

        private void SwitchPicture_MouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                this.Controls[(sender as PictureBox).Name.Replace("pic", "btn")].BackColor = Color.FromArgb(80, 80, 80);
                (sender as PictureBox).BackColor = Color.FromArgb(80, 80, 80);
            }
        }

        private void SwitchPicture_MouseLeave(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                this.Controls[(sender as PictureBox).Name.Replace("pic", "btn")].BackColor = Color.FromArgb(31, 32, 34);
                (sender as PictureBox).BackColor = Color.FromArgb(31, 32, 34);
            }
        }

        private void SwitchButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is StyleBtn)
            {
                this.Controls[(sender as StyleBtn).Name.Replace("btn", "pic")].BackColor = Color.FromArgb(80, 80, 80);
                (sender as StyleBtn).BackColor = Color.FromArgb(80, 80, 80);
            }
        }

        private void SwitchButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is StyleBtn)
            {
                this.Controls[(sender as StyleBtn).Name.Replace("btn", "pic")].BackColor = Color.FromArgb(31, 32, 34);
                (sender as StyleBtn).BackColor = Color.FromArgb(31, 32, 34);
            }
        }

        private void ChosingSwitch_Click(object sender, EventArgs e)
        {
            if (sender is StyleBtn)
            {
                object temp = this.Controls[(sender as StyleBtn).Name.Replace("btn", "pic")];
                sender = null;
                sender = temp;
            }

            else if (sender is PictureBox)
            {
                PictureBox Switch = (PictureBox)sender;

                if (Switch.Tag.Equals("Chosen"))
                {
                    Switch.Tag = "Not chosen";
                    pnlBtnIconChosen.Visible = false;
                    Switch = null;
                }
                else
                {
                    Switch.Tag = "Chosen";
                    pnlBtnIconChosen.Visible = true;
                    pnlBtnIconChosen.Location = new Point(Switch.Location.X + Switch.Size.Width - 10, Switch.Location.Y + Switch.Size.Height - 10);
                    pnlBtnIconChosen.BringToFront();
                    if (Switch == picswitch1)
                        chosenSwitch = 1;
                    else if (Switch == picswitch2)
                        chosenSwitch = 2;
                    else if (Switch == picswitch3)
                        chosenSwitch = 3;
                    else if (Switch == picswitch4)
                        chosenSwitch = 4;
                    else if (Switch == picswitch5)
                        chosenSwitch = 5;
                }
            }
        }

        private void btnOnlyThis_Click(object sender, EventArgs e)
        {
            foreach (Keycap c in Share.Keyboard.Keycaps)
                if (c.ID.Equals(keybuttonName))
                    c.Switch = chosenSwitch;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (Keycap c in Share.Keyboard.Keycaps)
                c.Switch = chosenSwitch;
        }
    }
}
