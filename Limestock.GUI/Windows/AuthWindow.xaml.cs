using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Limestock.GUI
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        // Close_btn event
        private void authClose_btn_Click(object sender, RoutedEventArgs e) { this.Close(); }
        
        // Dragging event
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Fungsi drag di window
            if(e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        // Masuk_btn event
        private void Masuk_Click(object sender, RoutedEventArgs e)
        {
            // Autentikasi textbox
            if ((string)userName.Text != null && (string)passWord.Password != null)
            {
                // Bikin thread mainWindow
                Window mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        // Enter_key event
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Kalo mencet enter di window auth
            if(e.Key == Key.Enter)
                Masuk_Click(sender, e);
        }
    }
}
