using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.Json;

namespace Core
{
    public class AppConfiguration
    {
        public static BrowserConfiguration Browser => BindConfiguration<BrowserConfiguration>();
        public static UserConfiguration User => BindConfiguration<UserConfiguration>();

        private static IConfigurationRoot configurationRoot;

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
