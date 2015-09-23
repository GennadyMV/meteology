using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using MeteologyEntity.Common;
using MeteologyEntity.Models;

namespace MeteologyEntity.Repositories
{
    public class SettingsRepository : IRepository<Settings>
    {
        #region IRepository<Measurement> Members

        void IRepository<Settings>.Save(Settings entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepository<Settings>.Update(Settings entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepository<Settings>.Delete(Settings entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        Settings IRepository<Settings>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Settings>().Add(Restrictions.Eq("ID", id)).UniqueResult<Settings>();
        }

        IList<Settings> IRepository<Settings>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Settings));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Settings>();
            }
        }

        #endregion
    }

}
