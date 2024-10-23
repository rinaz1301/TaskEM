using Bogus;
using Microsoft.Extensions.DependencyInjection;
using TaskEM.Repository;
using TaskEM.Service;

namespace TaskEM
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<ILogService, LogService>();
            var builder = services.BuildServiceProvider();
            builder.GetRequiredService<ILogService>();


            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "DeliveryOrders.txt");
            string logPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Journal.log");
            //ILogService service = new LogService();
            //service.Log(logPath);
            using (var logFile = new StreamWriter(logPath))
            {
                logFile.WriteLine("dfdf");
            }
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}