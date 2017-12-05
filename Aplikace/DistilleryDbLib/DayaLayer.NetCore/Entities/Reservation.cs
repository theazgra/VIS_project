namespace DataLayerNetCore.Entities
{
    public class Reservation
    {
        private Material _material;

        public int Id { get; set; }
        public double MaterialAmount { get; set; }

        [Xml.XmlIgnore]
        public Customer Customer { get; set; }

        [Xml.XmlIgnore]
        public Material Material
        {
            set
            {
                _material = value;
            }
            get
            {
                //Lazy loading
                if (_material == null)
                {
                    IDatabase db = DBFactory.GetDatabase(DBFactory.configuredDbType, DBFactory.configuredConnectionString);
                    _material = db.Select(new Material(), Material_Id);
                }

                return _material;
            }
        }



        public System.DateTime RequestedDateTime { get; set; }
        public System.DateTime ReservationDateTime { get; set; }

        [ForeignKey(typeof(Customer), "Id")]
        public int Customer_Id { get; set; }

        [ForeignKey(typeof(Material), "Id")]
        public int Material_Id { get; set; }
    }
}
