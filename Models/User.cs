namespace LaBestiaNet.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Weight { get; set; }
        public int Height { get; set; }
        public Handed Handed { get; set; }
       
      
    }
}