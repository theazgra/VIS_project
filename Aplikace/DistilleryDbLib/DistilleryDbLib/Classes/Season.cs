using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistilleryDbLib.Classes
{
    public class Season
    {
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public bool finished { get; set; }
        public int distillationCount { get; set; }
    }
}
