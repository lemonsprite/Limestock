using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Limestock.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private const int durasiMax = 5000;
        protected override void OnStartup(StartupEventArgs e)
        {
            // instansiasi splashScreen
            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();
            Stopwatch timer = new Stopwatch();
            
            // hitung time startup
            timer.Start();
            base.OnStartup(e);
            Window loginWindow = new AuthWindow();
            timer.Stop();

            // hitung waktu reboot splashScreen
            int waktuReboot = durasiMax - (int)timer.ElapsedMilliseconds;
            if (waktuReboot > 0)
                Thread.Sleep(waktuReboot);

            // finalisasi splashScreen
            splashScreen.Close();
            loginWindow.Show();

        }
    }
}
