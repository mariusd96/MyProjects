using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;
using Opera.NHibernateConfig;
using Opera.model;

namespace Opera.repository
{
    public class UserRepository
    {
        enum E { CREATE, UPDATE, DELETE };

        private NHibernateHelper helper = new NHibernateHelper();

        private string encrypt(string pass)
        {
            StringBuilder str = new StringBuilder(pass);
            //System.Windows.MessageBox.Show(str.ToString());
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                {
                    int codLitera = (int)pass[i];
                    int codA = (int)('a');
                    int codZ = (int)('z');
                    if (codLitera + 5 > codZ) codLitera = codA + (codLitera + 5 - codZ - 1);
                    else codLitera += 5;
                    str[i] = Convert.ToChar(codLitera);
                }
            }
            //System.Windows.MessageBox.Show(str.ToString());
            return str.ToString();
        }

        private string decrypt(string pass)
        {
            StringBuilder str = new StringBuilder(pass);
            //System.Windows.MessageBox.Show(str.ToString());
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                {
                    int codLitera = (int)pass[i];
                    int codA = (int)('a');
                    int codZ = (int)('z');
                    if (codLitera - 5 < codA) codLitera = codZ - Math.Abs(codLitera - 5 - codA + 1);
                    else codLitera -= 5;
                    str[i] = Convert.ToChar(codLitera);
                }
            }
            //System.Windows.MessageBox.Show(str.ToString());
            return str.ToString();
        }

        public Admin getAdminByAccount(User a)
        {
            Admin adminNou = new Admin();

            try
            {
                helper.OpenConnection();
                adminNou = helper.Session.QueryOver<Admin>().Where(x => x.Username == a.Username && x.Password == encrypt(a.Password)).SingleOrDefault();
                helper.Commit();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.CloseConnection();
            }

            return adminNou;
        }

        public Casier getCasierByAccount(User a)
        {
            Casier casierNou = new Casier();
            try
            {
                helper.OpenConnection();
                casierNou = helper.Session.QueryOver<Casier>().Where(x => x.Username == a.Username && x.Password == encrypt(a.Password)).SingleOrDefault();
                helper.Commit();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.CloseConnection();
            }
            
            return casierNou;
        }

        public List<Casier> getCasieri()
        {
            List<Casier> lc = new List<Casier>();
            try
            {
                helper.OpenConnection();
                lc = helper.Session.Query<Casier>().ToList();
                helper.Commit();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.CloseConnection();

                for (int i = 0; i < lc.Count; i++)
                {
                    lc[i].Password = decrypt(lc[i].Password);
                }
            }

            return lc;
        }

        public void operatiiCasier(Casier c, int optiune)
        {
            try
            {
                c.Password = encrypt(c.Password);
                helper.OpenConnection();
                if (optiune == (int)E.CREATE) helper.Session.Save(c);
                else if (optiune == (int)E.UPDATE) helper.Session.Update(c);
                else if (optiune == (int)E.DELETE) helper.Session.Delete(c);
                helper.Commit();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.CloseConnection();
            }
        }
    }
}
