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
    public class GrozaRepository : IRepository<Groza>
    {
        #region IRepository<Measurement> Members

        void IRepository<Groza>.Save(Groza entity)
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

        void IRepository<Groza>.Update(Groza entity)
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

        void IRepository<Groza>.Delete(Groza entity)
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

        Groza IRepository<Groza>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Groza>().Add(Restrictions.Eq("ID", id)).UniqueResult<Groza>();
        }

        IList<Groza> IRepository<Groza>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Groza));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Groza>();
            }
        }

        public IList<Groza> GetByPeriod(DateTime dateBgn, DateTime dateEnd)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Groza));
                criteria.Add(Restrictions.Between("fixed_at", dateBgn, dateEnd));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Groza>();
            }
        }

        public IList<Groza> GetByZOC(string ZOC)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Groza));
                criteria.Add(Restrictions.Eq("zoc", ZOC));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<Groza>();
            }
        }
        #endregion
    }

}
