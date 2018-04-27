using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Opera.view
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public void autentificare(EventHandler Autentificare_Click)
        {
            this.autentificareBtn.Click += new RoutedEventHandler(Autentificare_Click); //Autentificare_Click;
        }

        public string getUser()
        {
            return this.userTextBox.Text;
        }

        public string getPass()
        {
            return this.passwordBox.Password;
        }

        public void showMessage(String message)
        {
            MessageBox.Show(message);
        }

        public void closeWindow()
        {
            this.Close();
        }

        //public void minimizeWindow()
        //{
        //    this.WindowState = WindowState.Minimized;
        //}

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
