using TaskEM.Repository;
using TaskEM.Service;

namespace TaskEM
{
    internal class Program
    {
        static bool ValidateInputData()
        {
            try
            {
                Console.WriteLine("Введите район доставки:");
                var district = Console.ReadLine();
                Console.WriteLine("Введите начало времени доставки:");
                var firstTime = Console.ReadLine();


                return true;
            }
            catch(Exception ex)
            {
                return false;
                Console.WriteLine(ex.Message);
            }
            
        }
        
        static void Main(string[] args)
        {
           
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "DeliveryOrders.txt");
            string logPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Journal.log");

            ILogService logService = new LogService(logPath);
            IFIleRepository repository = new FileRepository(logService);


            var deliveryOrders =  repository.ReadFile(path);




            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}