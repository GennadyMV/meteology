using MeteologyEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeteologyWeb.Controllers
{
    public class GrozaController : Controller
    {
        //
        // GET: /Groza/

        public ActionResult Index()
        {
            DateTime dateCurr = DateTime.Now;
            DateTime dateBgn = new DateTime(dateCurr.Year, dateCurr.Month, 1);
            DateTime dateEnd = dateBgn.AddMonths(1);
            List<Groza> theGrozes = Groza.GetByPeriod(dateBgn, dateEnd);
            string theSeriesLong = "";
            int countSeriesLong = 0;
            for (int i = (int)(theGrozes.Min(x => x.Longitude)*10); i < (int)(theGrozes.Max(x => x.Longitude)*10); i++)
            {
                int count = theGrozes.Count(x => (int)(x.Longitude * 10) == i);
                countSeriesLong += count;
                theSeriesLong += count.ToString()+",";
            }
            char[] trims = {','};
            theSeriesLong = theSeriesLong.TrimEnd(trims);
            theSeriesLong = "[" + theSeriesLong + "]";
            ViewBag.SeriesLong = theSeriesLong;
            ViewBag.SeriesLongMin = (int)(theGrozes.Min(x => x.Longitude) * 10);
            ViewBag.CountCountrolLong = countSeriesLong;

            string theSeriesLat = "";
            int countSeriesLat = 0;
            for (int i = (int)(theGrozes.Min(x => x.Latitude) * 10); i < (int)(theGrozes.Max(x => x.Latitude) * 10); i++)
            {
                int count = theGrozes.Count(x => (int)(x.Latitude * 10) == i);
                countSeriesLat += count;
                theSeriesLat += count.ToString() + ",";
            }
            theSeriesLat = theSeriesLat.TrimEnd(trims);
            theSeriesLat = "[" + theSeriesLat + "]";
            ViewBag.SeriesLat = theSeriesLat;
            ViewBag.SeriesLatMin = (int)(theGrozes.Min(x => x.Latitude) * 10);
            ViewBag.CountCountrolLat = countSeriesLat;

            return View(theGrozes);
        }

    }
}
