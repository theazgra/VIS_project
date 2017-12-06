namespace DataLayerNetCore.Entities
{
    public class Customer : UserInfo
    {
        private City _city;

        public new int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string PersonalNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double DistilledVolume { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public string Note { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        [Xml.XmlIgnore]
        public City City
        {
            set
            {
                _city = value;
            }
            get
            {
                if (_city == null)
                {
                    _city = DBFactory.Configured().Select(new City(), City_Id);
                }
                return _city;
            }
        }

        [ForeignKey(typeof(City), "Id")]
        public int City_Id { get; set; }
    }

}
