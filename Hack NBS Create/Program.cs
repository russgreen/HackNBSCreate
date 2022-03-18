using System;
using System.Windows.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Hack_NBS_Create
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppCenter.Start("d37ecb53-e9fd-4b2d-bc76-44bf97393fe0",
                   typeof(Analytics), typeof(Crashes));
            AppCenter.Start("d37ecb53-e9fd-4b2d-bc76-44bf97393fe0",
                               typeof(Analytics), typeof(Crashes));

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
