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

using FoodDelivery.models;
using FoodDelivery.bll;
using System.Reflection;

namespace FoodDelivery.presentation
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            /*if (e.ClickCount == 2)
            {
                this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            }
            else DragMove();*/
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void autentificareBtn_Click(object sender, RoutedEventArgs e)
        {
            Cont a = new Cont(getUsername(), getPassword(), 'X');
            Client b = null;

            Type myType = typeof(Cont);
            FieldInfo[] fields = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            try
            {
                a = ContBLL.findUser(a);
                b = ClientBLL.getClientByUser(a);
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }

            /*foreach (FieldInfo info in fields)
            {
                MessageBox.Show(info.Name + ", " + info.GetValue(a).ToString());
            }*/

            if (a != null)
            {
                if (a.Rol == 'A')
                {
                    AdminWindow meniuAdministrator = new AdminWindow();
                    meniuAdministrator.Show();
                    this.Close();
                }
                else if (a.Rol == 'C')
                {
                    ClientWindow meniuClient = new ClientWindow(a, b);
                    meniuClient.Show();
                    this.Close();
                }
            }
            else MessageBox.Show("Acest cont nu exista");
        }

        private string getUsername()
        {
            return this.userTextBox.Text;
        }

        private string getPassword()
        {
            return this.passwordBox.Password;
        }
    }
}
