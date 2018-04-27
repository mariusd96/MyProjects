using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Opera.view;
using Opera.model;
using Opera.repository;

namespace Opera.controller
{
    public class LoginController
    {
        private LoginView view;
        private UserRepository userRepo;

        public LoginController(LoginView loginView, UserRepository userRepoModel)
        {
            view = loginView;
            userRepo = userRepoModel;
            view.autentificare(Autentificare_Click);
        }

        private void Autentificare_Click(object sender, EventArgs e)
        {
            User user = new User(view.getUser(), view.getPass());

            Admin resultAdmin = userRepo.getAdminByAccount(user);
            SpectacolRepository spectacolRepo = new SpectacolRepository();

            if (resultAdmin == null)
            {
                Casier resultCasier = userRepo.getCasierByAccount(user);
                if (resultCasier == null) view.showMessage("Date incorecte");
                else
                {
                    CasierView casierView = new CasierView();
                    CasierController cc = new CasierController(casierView, spectacolRepo);
                    view.showMessage("Bine ai venit, " + resultCasier.Nume + " !");
                    view.closeWindow();
                    casierView.Show();
                }
            }
            else
            {
                AdminView adminView = new AdminView();
                AdminController ac = new AdminController(adminView, userRepo, spectacolRepo);
                view.showMessage("Bine ai venit, " + resultAdmin.Username + " !");
                view.closeWindow();
                adminView.Show();
            }
            //Casier result = UserRepository.getCasierByAccount(user);

            //view.showMessage(user.Username + " " + user.Password);
        }
    }
}
