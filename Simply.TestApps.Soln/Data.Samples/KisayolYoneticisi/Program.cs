using System;
using System.Threading;
using System.Windows.Forms;

namespace KisayolYoneticisi
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Mutex mutex = new Mutex(true, typeof(Program).Assembly.GetName().Name, out bool createdNew);

            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmShortCutList());
            }
            else
            {
                MessageBox.Show("Program is already running!..", "Warning: Multiple Running");
            }
        }
    }
}