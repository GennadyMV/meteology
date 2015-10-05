using MeteologyEntity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeteologyEntity.Repositories.Groza;

namespace MeteologyEntity.Models.Groza
{
    public class Groza
    {
        public virtual int ID { get; set; }
        public virtual DateTime fixed_at {get; set;}
        public virtual double Latitude {get; set;}
        public virtual double Longitude {get; set;}
        public virtual int Intensity {get; set;}
        public virtual string zoc { get; set; }
        
        public Groza()
        {


        }

        public Groza(string file, string raw)
        {
            char[] separators = {' ', '!'};
            string[] tokens = raw.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string tokenDDMM = tokens[0];
            string tokenHHMIss = tokens[1];
            string tokenMicro = tokens[2];
            string tokenLatitude = tokens[3];
            string tokenLongitude = tokens[4];
            string tokenIntensity = tokens[5];

            int YYYY = DateTime.Now.Year;
            int MM = Convert.ToInt32(tokenDDMM.Substring(2,2));
            int DD = Convert.ToInt32(tokenDDMM.Substring(0,2));
            int HH = Convert.ToInt32(tokenHHMIss.Substring(0,2));
            int MI = Convert.ToInt32(tokenHHMIss.Substring(2,2));
            int SS = Convert.ToInt32(tokenHHMIss.Substring(4,2));
            int SI = Convert.ToInt32(tokenMicro.Substring(0,3));
            this.fixed_at = new DateTime(YYYY, MM, DD, HH, MI, SS, SI);

            this.Latitude = Convert.ToDouble(tokenLatitude.Substring(0, 3)) +
                Convert.ToDouble(tokenLatitude.Substring(3, 2)) / 60 +
                Convert.ToDouble(tokenLatitude.Substring(5, 2)) / 3600;


            this.Longitude = Convert.ToDouble(tokenLongitude.Substring(0, 3)) +
                Convert.ToDouble(tokenLongitude.Substring(3, 2)) / 60 +
                Convert.ToDouble(tokenLongitude.Substring(5, 2)) / 3600;

            this.Intensity = Convert.ToInt32(tokenIntensity);


            this.zoc = file;
        }
        public virtual void Save()
        {
            IRepository<Groza> repo = new GrozaRepository();
            repo.Save(this);
        }

        public virtual void Update()
        {
            IRepository<Groza> repo = new GrozaRepository();
            repo.Update(this);
        }

        public static List<Groza> GetByPeriod(DateTime dateBgn, DateTime dateEnd)
        {

            GrozaRepository repo = new GrozaRepository();
            return (List<Groza>)repo.GetByPeriod(dateBgn, dateEnd);
        }

        public static List<Groza> GetByZOC(string ZOC)
        {
            GrozaRepository repo = new GrozaRepository();
            return (List<Groza>)repo.GetByZOC(ZOC);
        }


    }
}
