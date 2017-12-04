using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistilleryDbLib.Classes
{
    public class MonthReport
    {
        public DateTime date { get; set; }
        public string surename { get; set; }
        public string adress { get; set; }
        public double absVolume { get; set; }
        public string materialName { get; set; }
        public bool payed { get; set; }
        public double price { get; set; }

    }
}
