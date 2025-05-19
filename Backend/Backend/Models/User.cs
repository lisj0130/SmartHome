namespace Backend.Models
{
    public class User
    {
        public int UserID { get; set; }  // PK
        public string GoogleId { get; set; }  
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
