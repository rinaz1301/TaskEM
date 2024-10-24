using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEM.Model;
using System.IO;
using TaskEM.Service;

namespace TaskEM.Repository
{
    internal class FileRepository : IFIleRepository
    {
        ILogService _logService;
        public FileRepository(ILogService logService)
        {
            _logService = logService;
        }

        public List<DeliveryOrder> ReadFile(string path)
        {
            List<DeliveryOrder> resultList = new List<DeliveryOrder>();
            try
            {
                using (var inFile = new StreamReader(path))
                {
                    string line;
                    while ((line = inFile.ReadLine()) != null)
                    {
                        DeliveryOrder deliveryOrder = new DeliveryOrder();
                        deliveryOrder.ToModel(line);
                        resultList.Add(deliveryOrder);
                    }
                }
            }
            catch(FileNotFoundException ex)
            {
                _logService.LogError(path + " файл не найден.");
            }
            catch(Exception ex)
            {
                _logService.LogError("Неправильный формат файла для чтения" + ex.Message);
            }
            return resultList;
        }
        public void CreateTestFile()
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "DeliveryOrders.txt");
            using(var outFile = new StreamWriter(path))
            {
                foreach(var line in CreateTestData())
                {
                    outFile.WriteLine(line);
                }
            }            
        }
        private List<DeliveryOrder> CreateTestData()
        {
            Faker<DeliveryOrder> faker = new Faker<DeliveryOrder>()
                .RuleFor(x => x.OrderId, x => x.UniqueIndex)
                .RuleFor(x => x.Weight, x => Math.Round(x.Random.Double(0, 100), 2))
                .RuleFor(x => x.District, x => GetRandomDistrict())
                .RuleFor(x => x.Time, x => x.Date.Between(new DateTime(2024, 10, 1), DateTime.Now));

            return faker.Generate(10).ToList();
        }
        private string GetRandomDistrict()
        {
            Dictionary<int, string> districts = new Dictionary<int, string>()
            {
                {0, "Московский" },
                {1, "Советский" },
                {2, "Вахитовский" },
                {3, "Ново-Савиносвкий" },
                {4, "Авиастроительный" },
                {5, "Заречный" },
                {6, "Лаишево" }
            };
            return districts.GetValueOrDefault(new Random().Next(districts.Count));
        }
    }
}
