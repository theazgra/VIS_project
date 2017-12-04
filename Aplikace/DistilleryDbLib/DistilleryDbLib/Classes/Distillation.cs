using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistilleryDbLib.Classes
{
    public class Distillation
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public double amount { get; set; }
        public double ethanolPercentage { get; set; }
        public double distilledVolume { get; set; }
        public double absoluteAlcoholVolume { get; set; }
        public double price { get; set; }
        public bool payed { get; set; }
        public int Customer_Id { get; set; }
        public int Material_Id { get; set; }
        public int Season_Id { get; set; }
        public int Period_Id { get; set; }
        public Customer Customer { get; set; }
        public Material Material { get; set; }
        public Season Season { get; set; }
        public Period Period { get; set; }
    }
}
