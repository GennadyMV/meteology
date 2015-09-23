using MeteologyEntity.Common;
using MeteologyEntity.Models;
using MeteologyEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeteologyeMediana.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/

        public ActionResult Index()
        {
            IRepository<Settings> repo = new SettingsRepository();
            Settings settings;
            List<Settings> theSettings = (List<Settings>)repo.GetAll();
            if (theSettings.Count == 0)
            {
                settings = new Settings();
                repo.Save(settings);
            }
            else
            {
                settings = theSettings[0];
            }
            return RedirectToAction("Details", new { ID = settings.ID });
        }

        //
        // GET: /Settings/Details/5

        public ActionResult Details(int id)
        {
            IRepository<Settings> repo = new SettingsRepository();
            return View(repo.GetById(id));
        }

        //
        // GET: /Settings/Edit/5

        public ActionResult Edit(int id)
        {
            IRepository<Settings> repo = new SettingsRepository();
            return View(repo.GetById(id));
        }

        //
        // POST: /Settings/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string Groza_FTP_host = collection.Get("Groza_FTP_host");
                string Groza_FTP_user = collection.Get("Groza_FTP_user");
                string Groza_FTP_pass = collection.Get("Groza_FTP_pass");
                Settings settings = new Settings()
                {
                    ID = id,
                    Groza_FTP_host = Groza_FTP_host,
                    Groza_FTP_user = Groza_FTP_user,
                    Groza_FTP_pass = Groza_FTP_pass                    
                };

                IRepository<Settings> repo = new SettingsRepository();
                repo.Update(settings);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
