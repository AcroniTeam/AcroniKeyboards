using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcroniUI.Custom.CustomModules
{
    public partial class KeycapParentModule : Form
    {
        public KeycapParentModule()
        {
            InitializeComponent();
            FadeIn();
        }

        #region FadeIn e FadeOut
        public virtual async void FadeOut(int delay)
        {
            while (Opacity > 0)
            {
                await Task.Delay(delay);
                Opacity -= 0.05;
            }
            Close();
        }

        public async void FadeIn()
        {
            while (Opacity < 1)
            {
                await Task.Delay(5);
                Opacity += 0.05;
            }
            Opacity = 1.0;
        }
        #endregion

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FadeOut(1);
        }
    }
}
