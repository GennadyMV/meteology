using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteologyCore.Logger
{
    public interface ILogger
    {
        void Log(string msg);
        void Error(string msg);
    }
}
