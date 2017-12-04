using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistilleryDbLib.Classes
{
    public class Customer
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string surename { get; set; }
        public string personalNumber { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public double distilledVolume { get; set; }
        public DateTime registrationDate { get; set; }
        public string note { get; set; }
        public string street { get; set; }
        public string houseNumber { get; set; }
        public int City_Id { get; set; }
        public City City { get; set; }
    }

}
