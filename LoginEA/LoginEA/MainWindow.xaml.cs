using System;
using System.Windows;

namespace LoginEA
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginWindow loginWindow;
        public MainWindow()
        {
            InitializeComponent();

            loginWindow = new LoginWindow();
            loginWindow.LoggedIn += LoginWindow_LoggedIn;
            loginWindow.LoggedOut += LoginWindow_LoggedOut;
            loginWindow.LoginCanceled += LoginWindow_LoginCanceled;
        }

        private void LoginWindow_LoggedIn(string token)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                TokenBox.Text = token;
            }));
        }

        private void LoginWindow_LoggedOut()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                TokenBox.Text = "Logged out...";
            }));
        }

        private void LoginWindow_LoginCanceled()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                TokenBox.Text = "Login canceled";
            }));
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            TokenBox.Text = "Logging in...";
            loginWindow.Login();
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            TokenBox.Text = "Logging out...";
            loginWindow.Logout();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loginWindow.Close();
        }
    }
}
