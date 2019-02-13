namespace MvcAuth.Models
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}