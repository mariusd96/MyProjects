using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;
using NHibernate.Cfg;

namespace Opera.NHibernateConfig
{
    public class NHibernateHelper
    {
        private ISessionFactory sessionFactory;
        private ITransaction transaction;
        private ISession session;

        public NHibernateHelper()
        {
            this.sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public void OpenConnection()
        {
            this.session = sessionFactory.OpenSession();
            this.transaction = this.session.BeginTransaction();
        }

        public void CloseConnection()
        {
            this.session.Close();
        }

        public void Commit()
        {
            this.transaction.Commit();
        }

        public void Rollback()
        {
            this.transaction.Rollback();
        }

        public IQuery CreateQuery(string hql)
        {
            return this.session.CreateQuery(hql);
        }

        public ISession Session
        {
            get { return this.session; }
        }

        public ITransaction Transaction
        {
            get { return this.transaction; }
        }
    }
}
