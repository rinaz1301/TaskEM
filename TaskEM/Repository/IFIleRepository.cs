using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEM.Model;

namespace TaskEM.Repository
{
    internal interface IFIleRepository
    {
        List<DeliveryOrder> ReadFile(string path);
        void CreateTestFile();
    }
}
