namespace DataLayerNetCore.Entities
{
    public class City
    {
        private District _district;
        private Region _region;

        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }

        [Xml.XmlIgnore]
        public string NameZip { get { return Name + " " + ZipCode; } }

        [Xml.XmlIgnore]
        public District District
        {
            set
            {
                _district = value;
            }
            get
            {
                if (_district == null)
                {
                    _district = DBFactory.Configured().Select(new District(), District_Id);
                }
                return _district;
            }
        }

        [Xml.XmlIgnore]
        public Region Region
        {
            set
            {
                _region = value;
            }
            get
            {
                if (_region == null)
                {
                    _region = DBFactory.Configured().Select(new Region(), Region_Id);
                }
                return _region;
            }
        }

        [ForeignKey(typeof(District), "Id")]
        public int District_Id { get; set; }

        [ForeignKey(typeof(Region), "Id")]
        public int Region_Id { get; set; }
    }
}
