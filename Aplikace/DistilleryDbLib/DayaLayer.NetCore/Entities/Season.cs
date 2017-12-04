namespace DataLayerNetCore.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime? EndDate { get; set; }
        public bool Finished { get; set; }
        public int DistillationCount { get; set; }
    }
}
