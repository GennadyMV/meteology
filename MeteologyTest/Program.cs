using MeteologyCore.Groza;
using MeteologyCore.Logger;
using MeteologyEntity.Helper;
using MeteologyEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeteologyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateSchema();
            //FTP_connect();
            //Groza_parser();
            RemoteAccessFolder();
            Console.WriteLine("Ok");
            Console.ReadLine();
        }
        static void RemoteAccessFolder()
        {
            //string fileName = @"\\10.8.5.123\obmen\ForWWW\geo\2015_09_23\wrf-arw\khv\1AmurOs_HBRK15.txt";
            //string fileName = @"\\10.8.2.40\rhm\operative\forecasts\2015_09_23\wrf-arw\khv\1AmurOs_HBRK15.txt";
            DateTime currDate = DateTime.Now;
            Settings theSetting = Settings.Get();

            string fileName = theSetting.Forecast_Folder + "\\" + currDate.ToString("yyyy_MM_dd") + "\\wrf-arw\\khv\\1AmurOs_HBRK15.txt";

                
            Console.WriteLine(fileName);
            try
            {
                Console.WriteLine(Helper.readFileAsUtf8(fileName));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        static void Groza_parser()
        {
            string _line = "!0309!001119 3249740 0514053 1304144  -488 23 2 0    3%%      ";
            MeteologyEntity.Models.Groza theGroza = new MeteologyEntity.Models.Groza("1578", _line);

        }
        static void FTP_connect()
        {
            
            Settings theSetting = Settings.Get();
            try
            {
                ILogger theLogger = new LoggerConsole();
                ILogger theLoggerNLog = new LoggerNLog();
                IGroza theGrozaFTP = new GrozaFTP(theSetting.Groza_FTP_host,
                    theSetting.Groza_FTP_user,
                    theSetting.Groza_FTP_pass,
                    theLoggerNLog);

                IGroza theGrozaDir = new GrozaDirectory("", theLogger);

                theGrozaFTP.Access();

                               
            }
            catch
            {
                Console.WriteLine("Ошибка");
            }
        }
        static void UpdateSchema()
        {

            MeteologyEntity.Common.NHibernateHelper.UpdateSchema();

        }
    }
}
