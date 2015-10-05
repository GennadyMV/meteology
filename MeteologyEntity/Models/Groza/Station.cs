using MeteologyEntity.Common;
using MeteologyEntity.Repositories;
using MeteologyEntity.Repositories.Groza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteologyEntity.Models.Groza
{
    public class Station
    {
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual string Name { get; set; }
        public virtual double Longitude { get; set; }
        public virtual double Latitude { get; set; }

        public Station()
        {
            Name = "";
        }



        public static Station GetById(int id)
        {
            IRepository<Station> repo = new StationRepository();
            return repo.GetById(id);
        }

        public virtual void Save()
        {
            IRepository<Station> repo = new StationRepository();
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
            repo.Save(this);
        }

        public virtual void Update()
        {
            IRepository<Station> repo = new StationRepository();
            this.updated_at = DateTime.Now;
            repo.Update(this);
        }

        public static List<Station> GetAll()
        {
            IRepository<Station> repo = new StationRepository();
            return (List<Station>)(repo.GetAll());
        }

        public virtual void Delete()
        {
            IRepository<Station> repo = new StationRepository();

            repo.Delete(this);
        }
    }
}
