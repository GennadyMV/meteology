using MeteologyEntity.Repositories;
using MeteologyEntity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeteologyEntity.Models
{
    public class Settings
    {
        public virtual int ID { get; set; }
        public virtual string Groza_FTP_host { get; set; }
        public virtual string Groza_FTP_user { get; set; }
        public virtual string Groza_FTP_pass { get; set; }
        public Settings()
        {
            Groza_FTP_host = "";
            Groza_FTP_user = "";
            Groza_FTP_pass = "";

        }
        public virtual void Save()
        {
            IRepository<Settings> repo = new SettingsRepository();
            repo.Save(this);
        }

        public virtual void Update()
        {
            IRepository<Settings> repo = new SettingsRepository();
            repo.Update(this);
        }

        public static Settings Get()
        {

            IRepository<Settings> repo = new SettingsRepository();
            return repo.GetAll()[0];
        }



    }
}
