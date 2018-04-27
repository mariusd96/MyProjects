using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Opera.view;
using Opera.model;
using Opera.repository;
using Opera.designPatterns;
using System.Windows.Controls;
using System.Windows.Input;

namespace Opera.controller
{
    class CasierController
    {
        private CasierView view;
        private SpectacolRepository spectacolRepo;

        public CasierController(CasierView casierView, SpectacolRepository spectacolRepoModel)
        {
            view = casierView;
            spectacolRepo = spectacolRepoModel;
            view.logout(Logout_Click);
            view.minimize(Minimize_Click);
            view.populateTable(spectacolRepo.getSpectacole(), CreareMatriceLocuri_Click);
            view.buyTicket(Buy_Click);
            view.exportBilet(Export_Click);
            view.showInfoSpectacol(InfoSpectacol_Click);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginView login = new LoginView();
            UserRepository userRepo = new UserRepository();
            LoginController controller = new LoginController(login, userRepo);
            view.closeWindow();
            login.Show();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            view.minimizeWindow();
        }

        private void CreareMatriceLocuri_Click(object sender, EventArgs e)
        {
            int index = -1;
            Button b = (Button)sender;

            index = Convert.ToInt32(b.Name.Substring(9, b.Name.Length - 9));
            Spectacol s = spectacolRepo.getSpectacole()[index];
            view.setMatriceLocuri(index, spectacolRepo.getBileteBySpectacol(s), MoveMatrice_Event, MatriceLeave_Event, Matrice_Click);
        }

        private void MoveMatrice_Event(object sender, MouseEventArgs e)
        {
            int nr = 0, i = 0, j = 0;
            Button b = (Button)sender;
            nr = Convert.ToInt32(b.Name.Substring(6, b.Name.Length - 6));
            i = nr / 20;
            j = nr % 20;

            view.setIndexLoc(i, j);
        }

        private void Matrice_Click(object sender, EventArgs e)
        {
            int nr = 0, i = 0, j = 0;
            Button b = (Button)sender;
            nr = Convert.ToInt32(b.Name.Substring(6, b.Name.Length - 6));
            i = nr / 20;
            j = nr % 20;

            view.setIndexLocClick(i, j);
        }

        private void MatriceLeave_Event(object sender, MouseEventArgs e)
        {
            view.setIndexLoc();
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            Bilet b = view.getBilet();

            if (b == null) view.showMessage("NU mai sunt bilete disponibile pentru acest spectacol");
            else
            {
                spectacolRepo.insertBilet(b);

                List<Spectacol> ls = spectacolRepo.getSpectacole();
                Spectacol s = new Spectacol();
                int index = -1;

                //cautam spectacolul cu id-ul de la bilet deoarece in UI se preia id-ul de la lista de spectacole returnata (spectacolele sunt in ord alfabetica si id-urile nu sunt in ordine)
                for (int i = 0; i < ls.Count && index == -1; i++)
                {
                    if(ls[i].IdSpectacol == b.IdSpectacol)
                    {
                        s = ls[i];
                        index = i;
                    }
                }

                view.setMatriceLocuri(index, spectacolRepo.getBileteBySpectacol(s), MoveMatrice_Event, MatriceLeave_Event, Matrice_Click);
                view.showMessage("Biletul a fost inregistrat");
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            string variantaExport = view.getExportType();
            string numeSpectacol = view.getSpectacolByTitlu();
            List<Bilet> listaBilete = view.getListaBilete(); 

            if (variantaExport != "" && numeSpectacol != "")
            {
                //view.showMessage(variantaExport);
                ExporterFactory exportFactory = new ExporterFactory();
                Exporter exporter = exportFactory.getExporter(variantaExport);
                exporter.export(numeSpectacol, listaBilete);

                view.showMessage("Fisier exportat cu succes!");
            }
            else view.showMessage("Spectacol/Varianta export neselectata!");
        }

        private void InfoSpectacol_Click(object sender, MouseButtonEventArgs e)
        {
            Spectacol s = view.getSpectacol();
            if (s != null)
            {
                List<DistributieOp> l_distributie_op = spectacolRepo.getActoriOp(s);
                string str = s.ToString();
                
                if (l_distributie_op.Count != 0)
                {
                    str += "\n\nDistributie\n";
                    
                    foreach (DistributieOp d in l_distributie_op)
                    {
                        str = str + "Actor: " + d.NumeActor + ", Rol: " + d.RolActor + "\n";
                    }
                    view.showMessage(str);
                }
                else
                {
                    List<DistributieBalet> l_distributie_balet = spectacolRepo.getActoriBalet(s);

                    str += "\n\nDistributie\n";
                    
                    foreach (DistributieBalet d in l_distributie_balet)
                    {
                        str = str + d.NumeActor + "\n";
                    }
                    view.showMessage(str);
                }
            }
        }
    }
}
