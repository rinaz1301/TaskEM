using Bogus;
using TaskEM.Model;
using TaskEM.Repository;

namespace TaskEM
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "DeliveryOrders.txt");
            FileRepository fileRepository = new FileRepository();
            fileRepository.CreateTestFile();
            var s = fileRepository.ReadFile(path);
            Console.WriteLine(s.Count);
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}