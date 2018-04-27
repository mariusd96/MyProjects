using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Opera.view;
using Opera.model;
using Opera.repository;
using System.Windows.Controls;

namespace Opera.controller
{
    class AdminController
    {
        private AdminView view;
        private UserRepository userRepo;
        private SpectacolRepository spectacoleRepo;

        public AdminController(AdminView adminView, UserRepository userRepoModel, SpectacolRepository spectacoleRepoModel)
        {
            view = adminView;
            userRepo = userRepoModel;
            spectacoleRepo = spectacoleRepoModel;

            view.logout(Logout_Click);
            view.minimize(Minimize_Click);
            view.populateTable(userRepo.getCasieri(), ModificareCont_Click);
            view.addCasier(InsertCasier_Click);
            view.modificareCasier(UpdateCasier_Click);
            view.stergereCasier(DeleteCasier_Click);

            //spectacole
            view.populateTableSpectacole(spectacoleRepo.getSpectacole(), ModificareSpectacol_Click);
            view.addSpectacol(InsertSpectacol_Click);
            view.modificareSpectacol(UpdateSpectacol_Click);
            view.stergereSpectacol(DeleteSpectacol_Click);

            //actori
            view.populateComboBox();
            view.cautareActoriSpectacol(cautare_Click);
            view.addActor(InsertActor_Click);
            view.modificareActor(UpdateActor_Click);
            view.stergereActor(DeleteActor_Click);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginView login = new LoginView();
            LoginController controller = new LoginController(login, userRepo);
            view.closeWindow();
            login.Show();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            view.minimizeWindow();
        }

        private void InsertCasier_Click(object sender, EventArgs e)
        {
            Casier c = view.getCasier();
            if (c != null)
            {
                userRepo.operatiiCasier(c, 0);
                view.clearCasierTextboxes();
                view.populateTable(userRepo.getCasieri(), ModificareCont_Click);
            }
            else view.showMessage("NU ati completat toate campurile");
        }

        private void ModificareCont_Click(object sender, EventArgs e)
        {
            int index = -1;
            Button b = (Button)sender;

            index = Convert.ToInt32(b.Name.Substring(9, b.Name.Length - 9));
            view.setCasierTextboxes(index);
        }

        private void UpdateCasier_Click(object sender, EventArgs e)
        {
            Casier c = view.getCasier();
            if (c != null)
            {
                userRepo.operatiiCasier(c, 1);
                //view.clearCasierTextboxes();
                view.populateTable(userRepo.getCasieri(), ModificareCont_Click);
            }
            else view.showMessage("NU ati completat toate campurile");
        }

        private void DeleteCasier_Click(object sender, EventArgs e)
        {
            Casier c = view.getCasier();
            if (c != null)
            {
                userRepo.operatiiCasier(c, 2);
                view.clearCasierTextboxes();
                view.populateTable(userRepo.getCasieri(), ModificareCont_Click);
            }
            else view.showMessage("NU ati completat toate campurile");
        }

        //--------------------------------------------spectacole----------------------------------------------
        private void ModificareSpectacol_Click(object sender, EventArgs e)
        {
            int index = -1;
            Button b = (Button)sender;

            index = Convert.ToInt32(b.Name.Substring(14, b.Name.Length - 14));
            //Spectacol s = spectacoleRepo.getSpectacole()[index];
            view.setSpectacolTextboxes(index);
            view.populateComboBox();
        }

        private void InsertSpectacol_Click(object senser, EventArgs e)
        {
            Spectacol s = view.getSpectacol();
            if (s != null)
            {
                spectacoleRepo.operatiiSpectacol(s, 0);
                view.clearSpectacolTextboxes();
                view.populateTableSpectacole(spectacoleRepo.getSpectacole(), ModificareSpectacol_Click);
                view.showMessage("Spectacol adaugat cu succes");
                view.populateComboBox();
            }
            else view.showMessage("NU ati completat toate campurile");
        }

        private void UpdateSpectacol_Click(object senser, EventArgs e)
        {
            Spectacol s = view.getSpectacol();
            if (s != null)
            {
                spectacoleRepo.operatiiSpectacol(s, 1);
                //view.clearSpectacolTextboxes();
                view.populateTableSpectacole(spectacoleRepo.getSpectacole(), ModificareSpectacol_Click);
                view.showMessage("Spectacol modificat cu succes");
            }
            else view.showMessage("NU ati completat toate campurile");
        }

        private void DeleteSpectacol_Click(object sender, EventArgs e)
        {
            Spectacol s = view.getSpectacol();
            if (s != null)
            {
                spectacoleRepo.operatiiSpectacol(s, 2);
                view.clearSpectacolTextboxes();
                view.populateTableSpectacole(spectacoleRepo.getSpectacole(), ModificareSpectacol_Click);
                view.showMessage("Spectacol sters cu succes");
                view.populateComboBox();
            }
            else view.showMessage("NU ati completat toate campurile");
        }

        //--------------------------------------------actori----------------------------------------------
        private void cautare_Click(object sender, EventArgs e)
        {
            Spectacol s = view.getSpectacolByTitlu();
            if (s != null)
            {
                //view.showMessage(s.ToString());
                List<DistributieOp> dist_Op = spectacoleRepo.getActoriOp(s);
                List<DistributieBalet> dist_Balet = spectacoleRepo.getActoriBalet(s);
                view.populateTableDistributie(dist_Op, dist_Balet, ModificareActor_Click);
                view.showTextboxes();
            }
            else view.showMessage("Nu ati selectat spectacolul");
        }

        private void ModificareActor_Click(object sender, EventArgs e)
        {
            int index = -1;
            Button b = (Button)sender;

            index = Convert.ToInt32(b.Name.Substring(10, b.Name.Length - 10));
            //Spectacol s = spectacoleRepo.getSpectacole()[index];
            view.setIndexActor(index);
            view.setActorTextboxes(index);
        }

        private void InsertActor_Click(object sender, EventArgs e)
        {
            if (view.getGenSpectacol() == "Balet")
            {
                DistributieBalet db = view.getActorBalet();
                spectacoleRepo.operatiiActorBalet(db, 0);
            }
            else
            {
                DistributieOp d_op = view.getActorOp();
                spectacoleRepo.operatiiActorOp(d_op, 0);
            }

            view.showMessage("Actor adaugat cu succes");
            Spectacol s = view.getSpectacolSelectat();
            List<DistributieOp> dist_Op = spectacoleRepo.getActoriOp(s);
            List<DistributieBalet> dist_Balet = spectacoleRepo.getActoriBalet(s);
            view.populateTableDistributie(dist_Op, dist_Balet, ModificareActor_Click);
            view.showTextboxes();
        }

        private void UpdateActor_Click(object sender, EventArgs e)
        {
            if (view.getGenSpectacol() == "Balet")
            {
                DistributieBalet db = view.getActorBalet();
                spectacoleRepo.operatiiActorBalet(db, 1);
            }
            else
            {
                DistributieOp d_op = view.getActorOp();
                spectacoleRepo.operatiiActorOp(d_op, 1);
            }

            view.showMessage("Actor modificat cu succes");
            Spectacol s = view.getSpectacolSelectat();
            List<DistributieOp> dist_Op = spectacoleRepo.getActoriOp(s);
            List<DistributieBalet> dist_Balet = spectacoleRepo.getActoriBalet(s);
            view.populateTableDistributie(dist_Op, dist_Balet, ModificareActor_Click);
            view.showTextboxes();
        }

        private void DeleteActor_Click(object sender, EventArgs e)
        {
            if (view.getGenSpectacol() == "Balet")
            {
                DistributieBalet db = view.getActorBalet();
                spectacoleRepo.operatiiActorBalet(db, 2);
            }
            else
            {
                DistributieOp d_op = view.getActorOp();
                spectacoleRepo.operatiiActorOp(d_op, 2);
            }

            view.showMessage("Actor sters cu succes");
            Spectacol s = view.getSpectacolSelectat();
            List<DistributieOp> dist_Op = spectacoleRepo.getActoriOp(s);
            List<DistributieBalet> dist_Balet = spectacoleRepo.getActoriBalet(s);
            view.populateTableDistributie(dist_Op, dist_Balet, ModificareActor_Click);
            view.showTextboxes();
        }
    }
}
