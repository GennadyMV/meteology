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
                string Forecast_Folder = collection.Get("Forecast_Folder");
                Settings settings = Settings.Get();

                settings.Forecast_Folder = Forecast_Folder;

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
