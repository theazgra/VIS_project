namespace DataLayerNetCore.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }

        [Xml.XmlIgnore]
        public string NameZip { get { return Name + " " + ZipCode; } }

        [Xml.XmlIgnore]
        public District District { get; set; }

        [Xml.XmlIgnore]
        public Region Region { get; set; }

        [ForeignKey(typeof(District), "Id")]
        public int District_Id { get; set; }

        [ForeignKey(typeof(Region), "Id")]
        public int Region_Id { get; set; }
    }
}
