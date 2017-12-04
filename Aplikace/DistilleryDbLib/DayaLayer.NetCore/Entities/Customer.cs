namespace DataLayerNetCore.Entities
{
    public class Customer : UserInfo
    {
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
        public City City { get; set; }

        [ForeignKey(typeof(City), "Id")]
        public int City_Id { get; set; }
    }

}
