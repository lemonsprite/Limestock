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
        private const int DURASI = 5000;
        protected override void OnStartup(StartupEventArgs e)
        {

            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();
            Stopwatch timer = new Stopwatch();
            timer.Start();

            base.OnStartup(e);
            Window loginWindow = new AuthWindow();
            timer.Stop();

            int sisaWaktu = DURASI - (int)timer.ElapsedMilliseconds;
            if (sisaWaktu > 0)
                Thread.Sleep(sisaWaktu);

            splashScreen.Close();
            loginWindow.Show();

        }
    }
}
