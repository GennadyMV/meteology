using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using MeteologyEntity.Common;
using MeteologyEntity.Models.Groza;

namespace MeteologyEntity.Repositories.Groza
{
    public class GrozaRepository : IRepository<MeteologyEntity.Models.Groza.Groza>
    {
        #region IRepository<Measurement> Members

        void IRepository<MeteologyEntity.Models.Groza.Groza>.Save(MeteologyEntity.Models.Groza.Groza entity)
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

        void IRepository<MeteologyEntity.Models.Groza.Groza>.Update(MeteologyEntity.Models.Groza.Groza entity)
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

        void IRepository<MeteologyEntity.Models.Groza.Groza>.Delete(MeteologyEntity.Models.Groza.Groza entity)
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

        MeteologyEntity.Models.Groza.Groza IRepository<MeteologyEntity.Models.Groza.Groza>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<MeteologyEntity.Models.Groza.Groza>().Add(Restrictions.Eq("ID", id)).UniqueResult<MeteologyEntity.Models.Groza.Groza>();
        }

        IList<MeteologyEntity.Models.Groza.Groza> IRepository<MeteologyEntity.Models.Groza.Groza>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(MeteologyEntity.Models.Groza.Groza));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<MeteologyEntity.Models.Groza.Groza>();
            }
        }

        public IList<MeteologyEntity.Models.Groza.Groza> GetByPeriod(DateTime dateBgn, DateTime dateEnd)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(MeteologyEntity.Models.Groza.Groza));
                criteria.Add(Restrictions.Between("fixed_at", dateBgn, dateEnd));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<MeteologyEntity.Models.Groza.Groza>();
            }
        }

        public IList<MeteologyEntity.Models.Groza.Groza> GetByZOC(string ZOC)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(MeteologyEntity.Models.Groza.Groza));
                criteria.Add(Restrictions.Eq("zoc", ZOC));
                criteria.AddOrder(Order.Desc("ID"));
                return criteria.List<MeteologyEntity.Models.Groza.Groza>();
            }
        }
        #endregion
    }

}
