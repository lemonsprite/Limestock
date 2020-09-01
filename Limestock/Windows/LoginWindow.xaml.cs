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

namespace Limestock.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        #region DragDrop Form saat kebuka
        /// <summary>
        /// Fungsi untuk dragdrop window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragDrop(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        #endregion

        #region Login Metod
        /// <summary>
        /// Metod buat login ke dashboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login(object sender, RoutedEventArgs e)
        {
            if ((string)userName.Text != null && (string)passWord.Password != null)
            {
                // Bikin thread mainWindow
                Window mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
        #endregion

        #region Metod Enter di form
        /// <summary>
        /// Bikin fungsi supaya bisa login tanpa harus neken tombol masuk (login)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterDipencet(object sender, KeyEventArgs e)
        {
            // Kalo mencet enter di window auth
            if (e.Key == Key.Enter)
                Login(sender, e);
        }
        #endregion

        #region Close button
        /// <summary>
        /// Fungsi close custom button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close(object sender, RoutedEventArgs e) => this.Close();
        #endregion
    }
}
