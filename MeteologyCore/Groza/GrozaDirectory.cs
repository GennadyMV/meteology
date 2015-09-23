using MeteologyCore.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteologyCore.Groza
{
    public class GrozaDirectory: IGroza
    {
        private string dirAccess;
        private ILogger theLogger;
        public GrozaDirectory(string dirAccess, ILogger theLogger)
        {
            this.dirAccess = dirAccess;
            this.theLogger = theLogger;
        }

        void IGroza.Access() {
            try
            {
                foreach (var item in Directory.GetFiles(dirAccess))
                {
                    theLogger.Log(item);
                }
            }
            catch (Exception ex)
            {
                theLogger.Error(ex.Message);
                theLogger.Error(ex.StackTrace);
            }
            
        }
    }
}
