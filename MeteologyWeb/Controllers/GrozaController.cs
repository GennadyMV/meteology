using MeteologyEntity.Models.Groza;
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
            return View();
        }
        public ActionResult Analize()
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

            string theCountSut = "";
            for (int i = 1; i <= 24; i++)
            {
                int count = theGrozes.Where(x => x.fixed_at.Hour == i - 1).Count();
                theCountSut += count.ToString() +",";
            }
            theCountSut = theCountSut.TrimEnd(trims);
            theCountSut = "[" + theCountSut + "]";
            ViewBag.CountSut = theCountSut;

            string theSumSutMinus = "";
            string theSumSutPlus = "";
            for (int i = 1; i <= 24; i++ )
            {
                int sumMinus = theGrozes.Where(x => x.fixed_at.Hour == i - 1).Where(x => x.Intensity < 0).Sum(x => x.Intensity);
                int sumPlus = theGrozes.Where(x => x.fixed_at.Hour == i - 1).Where(x => x.Intensity > 0).Sum(x => x.Intensity);
                theSumSutMinus += sumMinus.ToString() + ",";
                theSumSutPlus += sumPlus.ToString() + ",";
            }
            theSumSutMinus = "[" + theSumSutMinus.TrimEnd(trims) + "]";
            theSumSutPlus = "[" + theSumSutPlus.TrimEnd(trims) + "]";

            ViewBag.SumSutMinus = theSumSutMinus;
            ViewBag.SumSutPlus = theSumSutPlus;

            return View(theGrozes);
        }
        public ActionResult Scatter(int YYYY = -1, int MM = -1, int DD = -1)
        {

            DateTime currDate;
            try
            {
                currDate = new DateTime(YYYY, MM, DD);
            }
            catch
            {
                currDate = DateTime.Now;
            }

            ViewBag.currDate = currDate;
            ViewBag.prevDate = currDate.AddMonths(-1);
            ViewBag.nextDate = currDate.AddMonths(1);

            DateTime dateBgn = new DateTime(currDate.Year, currDate.Month, 1);
            DateTime dateEnd = dateBgn.AddMonths(1);
            List<Groza> theGrozes = Groza.GetByPeriod(dateBgn, dateEnd);

            char[] trims = { ',' };


            string theScatter = "";
            string theScatterMinus = "";
            string theScatterPlus = "";
            foreach (var item in theGrozes)
            {
                theScatter += "[" + item.Longitude.ToString().Replace(",", ".") + ", " + item.Latitude.ToString().Replace(",", ".") + "], ";
                if (item.Intensity < 0)
                {
                    theScatterMinus += "[" + item.Longitude.ToString().Replace(",", ".") + ", " + item.Latitude.ToString().Replace(",", ".") + "], ";
                }
                else
                {
                    theScatterPlus += "[" + item.Longitude.ToString().Replace(",", ".") + ", " + item.Latitude.ToString().Replace(",", ".") + "], ";
                }
            }
            theScatter = "[" + theScatter.TrimEnd(trims) + "]";
            theScatterMinus = "[" + theScatterMinus.TrimEnd(trims) + "]";
            theScatterPlus = "[" + theScatterPlus.TrimEnd(trims) + "]";
            ViewBag.Scatter = theScatter;
            ViewBag.ScatterMinus = theScatterMinus;
            ViewBag.ScatterPlus = theScatterPlus;

            Dictionary<string, string> theStationsData = new Dictionary<string, string>();
            foreach (var item in Station.GetAll())
            {
                theStationsData.Add(item.Name, 
                    "[[" + item.Longitude.ToString().Replace(",", ".") + ", " + item.Latitude.ToString().Replace(",", ".") + "]] ");
            }
            ViewBag.StationsData = theStationsData;
            return View(theGrozes);
        }
        public ActionResult Map(int YYYY = -1, int MM = -1, int DD = -1)
        {
            DateTime currDate;
            try
            {
                currDate = new DateTime(YYYY, MM, DD);
            }
            catch
            {
                currDate = DateTime.Now;
            }

            ViewBag.currDate = currDate;

            DateTime dateBgn = new DateTime(currDate.Year,
                currDate.Month,
                currDate.Day,
                0,0,0);
            DateTime dateEnd = new DateTime(currDate.Year,
                currDate.Month,
                currDate.Day,
                23,59,0);
            List<Groza> theGrozes = Groza.GetByPeriod(dateBgn, dateEnd);

            return View(theGrozes);
        }
    }
}
