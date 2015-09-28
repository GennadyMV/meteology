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



            string theSeriesSumLongMinus = "";
            string theSeriesSumLongPlus = "";
            int countSeriesSumLongPlus = 0;
            int countSeriesSumLongMinus = 0;
            for (int i = (int)(theGrozes.Min(x => x.Longitude) * 10); i < (int)(theGrozes.Max(x => x.Longitude) * 10); i++)
            {
                int countPlus = theGrozes.Where(x => (int)(x.Longitude * 10) == i).Where(x => x.Intensity > 0).Sum(x => x.Intensity);
                int countMinus = theGrozes.Where(x => (int)(x.Longitude * 10) == i).Where(x => x.Intensity < 0).Sum(x => x.Intensity);
                countSeriesSumLongPlus += countPlus;
                countSeriesSumLongMinus += countMinus;
                theSeriesSumLongPlus += countPlus.ToString() + ",";
                theSeriesSumLongMinus += countMinus.ToString() + ",";
            }
            theSeriesSumLongPlus = theSeriesSumLongPlus.TrimEnd(trims);
            theSeriesSumLongMinus = theSeriesSumLongMinus.TrimEnd(trims);
            theSeriesSumLongPlus = "[" + theSeriesSumLongPlus + "]";
            theSeriesSumLongMinus = "[" + theSeriesSumLongMinus + "]";
            ViewBag.SeriesSumLongPlus = theSeriesSumLongPlus;
            ViewBag.SeriesSumLongMinus = theSeriesSumLongMinus;
            ViewBag.SeriesSumLongMin = (int)(theGrozes.Min(x => x.Latitude) * 10);
            ViewBag.ControlSeriesSumLong = countSeriesSumLongPlus;




            string theSeriesSumLatMinus = "";
            string theSeriesSumLatPlus = "";
            int countSeriesSumLatPlus = 0;
            int countSeriesSumLatMinus = 0;
            for (int i = (int)(theGrozes.Min(x => x.Latitude) * 10); i < (int)(theGrozes.Max(x => x.Latitude) * 10); i++)
            {
                int countPlus = theGrozes.Where(x => (int)(x.Latitude * 10) == i).Where(x => x.Intensity > 0).Sum(x => x.Intensity);
                int countMinus = theGrozes.Where(x => (int)(x.Latitude * 10) == i).Where(x => x.Intensity < 0).Sum(x => x.Intensity);
                countSeriesSumLatPlus += countPlus;
                countSeriesSumLatMinus += countMinus;
                theSeriesSumLatPlus += countPlus.ToString() + ",";
                theSeriesSumLatMinus += countMinus.ToString() + ",";
            }
            theSeriesSumLatPlus = theSeriesSumLatPlus.TrimEnd(trims);
            theSeriesSumLatMinus = theSeriesSumLatMinus.TrimEnd(trims);
            theSeriesSumLatPlus = "[" + theSeriesSumLatPlus + "]";
            theSeriesSumLatMinus = "[" + theSeriesSumLatMinus + "]";
            ViewBag.SeriesSumLatPlus = theSeriesSumLatPlus;
            ViewBag.SeriesSumLatMinus = theSeriesSumLatMinus;
            ViewBag.SeriesSumLatMin = (int)(theGrozes.Min(x => x.Latitude) * 10);
            ViewBag.ControlSeriesSumLat = countSeriesSumLatPlus;



            return View(theGrozes);
        }

    }
}
