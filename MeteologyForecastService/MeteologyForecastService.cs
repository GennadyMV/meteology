using MeteologyCore.Logger;
using MeteologyEntity.Helper;
using MeteologyEntity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeteologyForecastService
{
    public partial class MeteologyForecastService : ServiceBase
    {
        Thread NewTread = new Thread(new ThreadStart(Searchmapdrive.main));
        public MeteologyForecastService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            NewTread.Start();
        }

        protected override void OnStop()
        {
            NewTread.Abort();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            ILogger theLogger = new LoggerNLog();
            theLogger.Log("timer1_Tick: Start");

            Settings theSettings = Settings.Get();
           
            try
            {
                theLogger.Log("Forecast: Access");
                theLogger.Log(theSettings.Forecast_Folder);

                DateTime currDate = DateTime.Now;

                string fileName = theSettings.Forecast_Folder + "\\" + currDate.ToString("yyyy_MM_dd") + "\\wrf-arw\\khv\\1AmurOs_HBRK15.txt";
                
                theLogger.Log(fileName);
                theLogger.Log(Helper.readFileAsUtf8(fileName));
            }
            catch (Exception ex)
            {
                theLogger.Error(ex.Message);
                theLogger.Error(ex.StackTrace);
            }
            finally
            {
                //timer1.Enabled = true;
            }
        }
    }
}
