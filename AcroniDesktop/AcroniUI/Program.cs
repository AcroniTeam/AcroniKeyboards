using System;
using System.Windows.Forms;
using System.Threading;
using AcroniUI.Custom;
using AcroniControls;
using AcroniUI.LoginAndSignUp;
using AcroniLibrary.SQL;
using System.IO;

namespace AcroniUI
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
            if (Environment.MachineName.Equals("NPIKDNINK"))
                Application.Run(new Template());
            else
                Application.Run(new LoginAndSignUp.FrmLogin());
        }
    }
}
