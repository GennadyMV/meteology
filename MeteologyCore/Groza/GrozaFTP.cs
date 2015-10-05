using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteologyCore.Logger;
using System.IO;

namespace MeteologyCore.Groza
{
    public class GrozaFTP:IGroza
    {
        private string Groza_FTP_host;
        private string Groza_FTP_user;
        private string Groza_FTP_pass;
        private ILogger theLogger;


        public GrozaFTP(string host, string user, string pass, ILogger theLogger)
        {
            this.Groza_FTP_host = host;
            this.Groza_FTP_user = user;
            this.Groza_FTP_pass = pass;
            this.theLogger = theLogger;
        }

        void IGroza.Access() {
            try
            {
                Ftp.Client theFTP = new Ftp.Client("ftp://" + Groza_FTP_host, Groza_FTP_user, Groza_FTP_pass);

                foreach (var item in theFTP.ListDirectory())
                {
                    theLogger.Log(item);

                    if (MeteologyEntity.Models.Groza.Groza.GetByZOC(item).Count > 0)
                    {
                        theLogger.Log("Count > 0");
                        continue;
                    }
                    theLogger.Log("Count == 0");

                    string fileTemp = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".zoc";
                    theFTP.DownloadFile(item, fileTemp);

                    foreach (var line in File.ReadAllLines(fileTemp))
                    {
                        theLogger.Log(line);
                        MeteologyEntity.Models.Groza.Groza theGroza = new MeteologyEntity.Models.Groza.Groza(item, line);

                        theGroza.Save();
                    }
                    File.Delete(fileTemp);

                }
            }
            catch (Exception ex)
            {
                theLogger.Error(ex.Message);
                theLogger.Error(ex.StackTrace);
                theLogger.Error(this.Groza_FTP_host);
                theLogger.Error(this.Groza_FTP_user);
                theLogger.Error(this.Groza_FTP_pass);
                if (ex.InnerException != null)
                {
                    theLogger.Error(ex.InnerException.Message);
                }
            }
        }
    }
}
