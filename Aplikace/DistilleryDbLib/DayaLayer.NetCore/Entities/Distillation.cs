using System;

namespace DataLayerNetCore.Entities
{
    public class Distillation
    {
        private Customer _customer;
        private Material _material;
        private Season _season;
        private Period _period;

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
        public Customer Customer
        {
            set
            {
                _customer = value;
            }
            get
            {
                if (_customer == null)
                {
                    _customer = DBFactory.Configured().Select(new Customer(), Customer_Id);
                }
                return _customer;
            }
        }

        [Xml.XmlIgnore]
        public Material Material
        {
            set
            {
                _material = value;
            }
            get
            {
                if (_material == null)
                {
                    _material = DBFactory.Configured().Select(new Material(), Material_Id);
                }
                return _material;
            }
        }

        [Xml.XmlIgnore]
        public Season Season
        {
            set
            {
                _season = value;
            }
            get
            {
                if (_season == null)
                {
                    _season = DBFactory.Configured().Select(new Season(), Season_Id);
                }
                return _season;
            }
        }

        [Xml.XmlIgnore]
        public Period Period
        {
            set
            {
                _period = value;
            }
            get
            {
                if (_period == null)
                {
                    _period = DBFactory.Configured().Select(new Period(), Period_Id);
                }
                return _period;
            }
        }


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
