namespace Core
{
    public class UserModel : IConfiguration
    {
        public string SectionName => "User";

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
