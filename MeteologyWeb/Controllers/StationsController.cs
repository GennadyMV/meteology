using MeteologyEntity.Common;
using MeteologyEntity.Models;
using MeteologyEntity.Models.Groza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeteologyWeb.Controllers
{
    public class StationsController : Controller
    {
        //
        // GET: /Stations/

        public ActionResult Index()
        {
            
            return View(Station.GetAll());
        }

        public ActionResult Map()
        {
            return View(Station.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                Station model = new Station(); ;
                model.Name = collection.Get("Name");
                model.Latitude = Convert.ToDouble(collection.Get("Latitude").Replace(".",","));
                model.Longitude = Convert.ToDouble(collection.Get("Longitude").Replace(".", ","));
                model.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return this.Create();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(Station.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            
            try
            {   
                Station model = Station.GetById(id);
                model.Name = collection.Get("Name");
                model.Latitude = Convert.ToDouble(collection.Get("Latitude").Replace(".",","));
                model.Longitude = Convert.ToDouble(collection.Get("Longitude").Replace(".",","));
                model.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return this.Edit(id);
            }
        }

        public ActionResult Delete(int id)
        {
            Station model = Station.GetById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Station model = Station.GetById(id);

                model.Delete();

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.error = e.ToString();

                return View();
            }
        }

    }
}
