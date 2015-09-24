using MeteologyEntity.Helper;
using MeteologyEntity.Models;
using MeteologyWebForecast.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeteologyWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AmurOs_HBRK15(int YYYY=-1, int MM=-1, int DD=-1)
        {
            DateTime currDate = DateTime.Now;

            try
            {
                currDate = new DateTime(YYYY, MM, DD);
            }
            catch
            {

            }

            try
            {


                ViewBag.currDate = currDate;
                Settings theSetting = Settings.Get();

                ViewBag.Forecast_Folder = theSetting.Forecast_Folder;

                string fileName = theSetting.Forecast_Folder + "\\" + currDate.ToString("yyyy_MM_dd") + "\\wrf-arw\\khv\\1AmurOs_HBRK15.txt";

                //fileName = @"\\10.8.2.40\rhm\operative\forecasts\2015_09_23\wrf-arw\khv\1AmurOs_HBRK15.txt";
                //M:\ForWWW\geo
               // fileName = @"\\10.8.5.123\obmen\ForWWW\geo\2015_09_23\wrf-arw\khv\1AmurOs_HBRK15.txt";

                FileInfo fi = new FileInfo(fileName);
                var exists = fi.Exists;

                //if (!exists)
                //{
                //    ViewBag.Error = "Файл " + fileName + " не найден!";
                //    return View();
                //}

                View_AmurOsHBRK15 theView = new View_AmurOsHBRK15();
                int i = 0;
                string lines = Helper.readFileAsUtf8(fileName);
                string[] sep = {"\r\n"};
                foreach (var line in lines.Split(sep, StringSplitOptions.RemoveEmptyEntries))
                {

                    i++;
                    if (i == 1)
                    {
                        theView.Title = line;
                        continue;
                    }
                    if (2 <= i && i <= 5)
                    {
                        theView.Comment += line + " ";
                        continue;
                    }
                    if (6 <= i && i <= 9)
                    {
                        continue;
                    }
                    string[] seporator = { "|" };
                    string[] tokens = line.Split(seporator, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens.Count() <= 1)
                    {
                        continue;
                    }

                    View_AmurOsHBRK15.Bassein theBassein = new View_AmurOsHBRK15.Bassein();
                    theBassein.Name = tokens[0];
                    theBassein.five01 = MeteologyEntity.Helper.Helper.ConvertDecimal(tokens[1]);
                    theBassein.five02 = MeteologyEntity.Helper.Helper.ConvertDecimal(tokens[2]);
                    theBassein.five03 = MeteologyEntity.Helper.Helper.ConvertDecimal(tokens[3]);
                    theBassein.five04 = MeteologyEntity.Helper.Helper.ConvertDecimal(tokens[4]);
                    theBassein.five05 = MeteologyEntity.Helper.Helper.ConvertDecimal(tokens[5]);
                    theBassein.five06 = MeteologyEntity.Helper.Helper.ConvertDecimal(tokens[6]);

                    theView.Basseins.Add(theBassein);
                }

                return View(theView);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message + " " + ex.StackTrace;
            }
            return View();
        }

    }
}
