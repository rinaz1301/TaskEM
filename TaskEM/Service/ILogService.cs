using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEM.Service
{
    internal interface ILogService
    {
        void Log(string message);
        void LogError(string message);
    }
}
