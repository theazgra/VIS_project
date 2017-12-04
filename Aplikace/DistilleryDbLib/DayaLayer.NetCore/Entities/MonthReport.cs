namespace DataLayerNetCore.Entities
{
    public class MonthReport
    {
        public System.DateTime Date { get; set; }
        public string Surename { get; set; }
        public string Adress { get; set; }
        public double AbsVolume { get; set; }
        public string MaterialName { get; set; }
        public bool Payed { get; set; }
        public double Price { get; set; }
    }
}
