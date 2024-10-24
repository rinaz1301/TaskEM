using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEM.Service
{
    internal class LogService : ILogService
    {
        string logFilePath;
        public LogService(string path)
        {
            logFilePath = path;
        }

        public void Log(string message)
        {
            using (var logFile = new StreamWriter(logFilePath, true))
            {
                logFile.WriteLine($"[{DateTime.Now}] {message}");
            }
        }
        public void LogError(string message)
        {
            using (var logFile = new StreamWriter(logFilePath, true))
            {
                logFile.WriteLine($"[{DateTime.Now}] Ошибка: {message}");
                Console.WriteLine($"Ошибка: {message}");
            }
        }
    }
}
