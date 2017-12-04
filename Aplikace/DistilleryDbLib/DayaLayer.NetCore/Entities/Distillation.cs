using System;

namespace DataLayerNetCore.Entities
{
    public class Distillation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Amount { get; set; }
        public double EthanolPercentage { get; set; }
        public double DistilledVolume { get; set; }
        public double AbsoluteAlcoholVolume { get; set; }
        public double Price { get; set; }
        public bool Payed { get; set; }

        [Xml.XmlIgnore]
        public Customer Customer { get; set; }

        [Xml.XmlIgnore]
        public Material Material { get; set; }

        [Xml.XmlIgnore]
        public Season Season { get; set; }

        [Xml.XmlIgnore]
        public Period Period { get; set; }


        [ForeignKey(typeof(Customer), "Id")]
        public int Customer_Id { get; set; }

        [ForeignKey(typeof(Material), "Id")]
        public int Material_Id { get; set; }

        [ForeignKey(typeof(Season), "Id")]
        public int Season_Id { get; set; }

        [ForeignKey(typeof(Period), "Id")]
        public int Period_Id { get; set; }

    }
}
