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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace Cabinet_medical
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller c = new Controller();

        public MainWindow()
        {
            InitializeComponent();

            user_textBox1.Text = null;
            passwordBox1.Password = null;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }
            else
            {
                this.DragMove();
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            fct_meniu();
        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                fct_meniu();
            }
        }

        private void fct_meniu()
        {
            c.autentificare(user_textBox1.Text, passwordBox1.Password);
            MessageBox.Show(c.mesaj);

            if (c.drept_admin == 'N')
            {
                Meniu_medic window = new Meniu_medic(c);
                window.Show();
                this.Hide();
            }
            else if (c.drept_admin == 'Y')
            {
                Meniu_admin window = new Meniu_admin();
                window.Show();
                this.Hide();
            }
        }
    }
}
