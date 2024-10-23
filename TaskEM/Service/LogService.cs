using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEM.Service
{
    internal class LogService : ILogService
    {
        public void Log(string path)
        {
            using (var logFile = new StreamWriter(path))
            {
                logFile.WriteLine("dfdf\n");
            }
        }
    }
}
