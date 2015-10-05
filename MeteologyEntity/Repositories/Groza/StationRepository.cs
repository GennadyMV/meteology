using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeteologyEntity.Common;
using NHibernate;
using NHibernate.Criterion;
using MeteologyEntity.Models.Groza;

namespace MeteologyEntity.Repositories.Groza
{
    public class StationRepository : IRepository<Station>
    {
        #region IRepository<Station> Members

        void IRepository<Station>.Save(MeteologyEntity.Models.Groza.Station entity)
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

        void IRepository<Station>.Update(Station entity)
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

        void IRepository<Station>.Delete(Station entity)
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

        Station IRepository<Station>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<Station>().Add(Restrictions.Eq("ID", id)).UniqueResult<Station>();
        }


        IList<Station> IRepository<Station>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Station));
                criteria.AddOrder(Order.Asc("ID"));
                return criteria.List<Station>();
            }
        }

        #endregion
    }
}
