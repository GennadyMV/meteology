using MeteologyCore.Groza;
using MeteologyCore.Logger;
using MeteologyEntity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MeteologyGrozaService
{
    public partial class MeteologyGrozaService : ServiceBase
    {
        public MeteologyGrozaService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            ILogger theLogger = new LoggerNLog();
            theLogger.Log("OnStart");
        }

        protected override void OnStop()
        {
            ILogger theLogger = new LoggerNLog();
            theLogger.Log("OnStop");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ILogger theLogger = new LoggerNLog();
            theLogger.Log("timer1_Tick: Start");

            Settings theSettings = Settings.Get();
            IGroza theGroza = new GrozaFTP(theSettings.Groza_FTP_host,
                theSettings.Groza_FTP_user,
                theSettings.Groza_FTP_pass,
                theLogger);

            try
            {
                theLogger.Log("Groza: Access");
                theGroza.Access();
            }
            catch (Exception ex)
            {
                theLogger.Error(ex.Message);
                theLogger.Error(ex.StackTrace);
            }
            finally
            {
                timer1.Enabled = true;
            }
            


        }
    }
}
