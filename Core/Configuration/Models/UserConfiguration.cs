using Core.Configuration.Logic;

namespace Core.Configuration.Models
{
    public class UserConfiguration : IConfiguration
    {
        public string SectionName => "User";

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
