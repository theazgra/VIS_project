namespace DataLayerNetCore.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public double MaterialAmount { get; set; }

        [Xml.XmlIgnore]
        public Customer Customer { get; set; }

        [Xml.XmlIgnore]
        public Material Material { get; set; }
        public System.DateTime RequestedDateTime { get; set; }
        public System.DateTime ReservationDateTime { get; set; }

        [ForeignKey(typeof(Customer), "Id")]
        public int Customer_Id { get; set; }

        [ForeignKey(typeof(Material), "Id")]
        public int Material_Id { get; set; }
    }
}
