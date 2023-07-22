using Core.Configuration.Models;
using Microsoft.Extensions.Configuration;

namespace Core.Configuration.Logic
{
    public class AppConfiguration
    {
        private static IConfigurationRoot configurationRoot;

        public static BrowserConfiguration Browser => BindConfiguration<BrowserConfiguration>();
        public static ApiConfiguration Api => BindConfiguration<ApiConfiguration>();
        public static UserConfiguration User => BindConfiguration<UserConfiguration>();

        static AppConfiguration()
        {
            configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appdata.json", optional: true, reloadOnChange: true)
                .Build();
        }

        private static T BindConfiguration<T>() where T : IConfiguration, new()
        {
            var config = new T();

            configurationRoot.GetSection(config.SectionName).Bind(config);
            return config;
        }

        public static string GetValue(string key)
        {
            return configurationRoot[key];
        }
    }
}
