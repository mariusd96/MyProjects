using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Opera.NHibernateConfig;
using Opera.model;

namespace Opera.repository
{
    class SpectacolRepository
    {
        enum E { CREATE, UPDATE, DELETE};

        private NHibernateHelper helper = new NHibernateHelper();

        public List<Spectacol> getSpectacole()
        {
            List<Spectacol> ls = new List<Spectacol>();
            try
            {
                helper.OpenConnection();
                ls = helper.Session.Query<Spectacol>().OrderBy(x => x.Titlu).ToList();
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

            return ls;
        }

        public List<Bilet> getBileteBySpectacol(Spectacol s)
        {
            List<Bilet> lb = new List<Bilet>();
            try
            {
                helper.OpenConnection();
                lb = helper.Session.Query<Bilet>().Where(x => x.IdSpectacol == s.IdSpectacol).ToList();
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

            return lb;
        }

        public void insertBilet(Bilet b)
        {
            try
            {
                helper.OpenConnection();
                helper.Session.Save(b);
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
        }

        public List<DistributieOp> getActoriOp(Spectacol s)
        {
            List<DistributieOp> l_distributie = new List<DistributieOp>();

            try
            {
                helper.OpenConnection();
                l_distributie = helper.Session.Query<DistributieOp>().Where(x => x.IdSpectacol == s.IdSpectacol).ToList();
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

            return l_distributie;
        }

        public List<DistributieBalet> getActoriBalet(Spectacol s)
        {
            List<DistributieBalet> l_distributie = new List<DistributieBalet>();

            try
            {
                helper.OpenConnection();
                l_distributie = helper.Session.Query<DistributieBalet>().Where(x => x.IdSpectacol == s.IdSpectacol).ToList();
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
            
            return l_distributie;
        }

        public void operatiiSpectacol(Spectacol s, int optiune)
        {
            try
            {
                helper.OpenConnection();
                if(optiune == (int)E.CREATE) helper.Session.Save(s);
                else if (optiune == (int)E.UPDATE) helper.Session.Update(s);
                else if (optiune == (int)E.DELETE) helper.Session.Delete(s);
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

        public void operatiiActorBalet(DistributieBalet db, int optiune)
        {
            try
            {
                helper.OpenConnection();
                if (optiune == (int)E.CREATE) helper.Session.Save(db);
                else if (optiune == (int)E.UPDATE) helper.Session.Update(db);
                else if (optiune == (int)E.DELETE) helper.Session.Delete(db);
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

        public void operatiiActorOp(DistributieOp d_op, int optiune)
        {
            try
            {
                helper.OpenConnection();
                if (optiune == (int)E.CREATE) helper.Session.Save(d_op);
                else if (optiune == (int)E.UPDATE) helper.Session.Update(d_op);
                else if (optiune == (int)E.DELETE) helper.Session.Delete(d_op);
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
