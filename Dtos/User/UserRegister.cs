namespace LaBestiaNet.Dtos.User
{
    public class UserRegister
    {
        public string UserName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Weight { get; set; }
        public int Height { get; set; }
        public Handed Handed { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
