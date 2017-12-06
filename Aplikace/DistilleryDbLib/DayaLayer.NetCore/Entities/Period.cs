namespace DataLayerNetCore.Entities
{
    public class Period
    {
        private Season _season;
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime? EndDate { get; set; }
        public bool Finished { get; set; }

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


        [ForeignKey(typeof(Season), "Id")]
        public int Season_Id { get; set; }
    }
}
