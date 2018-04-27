using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Opera.view;
using Opera.controller;
using Opera.repository;

namespace Opera.start
{
    public class Start
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //System.Windows.MessageBox.Show("Ceva frumos");
            var app = new Application();

            LoginView login = new LoginView();
            UserRepository userRepo = new UserRepository();
            LoginController controller = new LoginController(login, userRepo);
            login.Show();

            app.Run(login);
            //System.Windows.MessageBox.Show("Ceva frumos");
        }
    }
}
