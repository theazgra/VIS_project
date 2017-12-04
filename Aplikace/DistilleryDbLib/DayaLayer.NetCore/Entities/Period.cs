namespace DataLayerNetCore.Entities
{
    public class Period
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime? EndDate { get; set; }
        public bool Finished { get; set; }

        [Xml.XmlIgnore]
        public Season Season { get; set; }

        [ForeignKey(typeof(Season), "Id")]
        public int Season_Id { get; set; }
    }
}
