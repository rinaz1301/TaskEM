using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEM.Model
{
    internal class DeliveryOrder
    {
        public int OrderId { get; set; }
        public double Weight { get; set; }
        public string District { get; set; }
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return $"{OrderId} {Weight} {District} {Time}";
        }
        public void ToModel(string text)
        {
            try
            {
                string[] elems = text.Split(' ');
                OrderId = Convert.ToInt32(elems[0]);
                Weight = Convert.ToDouble(elems[1]);
                District = elems[2];
                Time = Convert.ToDateTime(elems[3] + " " + elems[4]);
            }
            catch(FormatException ex)
            {

            }
        }
    }
}
