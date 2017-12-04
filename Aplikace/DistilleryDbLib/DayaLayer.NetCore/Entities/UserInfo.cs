namespace DataLayerNetCore.Entities
{
    public class UserInfo
    {
        const int BASE = 0;        
        public const int Employee = BASE + 1;
        public const int Administrator = BASE + 2;
        public const int Customer = BASE + 3;

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserLevel { get; set; }
    }
}
