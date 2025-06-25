using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Config
{
    public static class ConfigurationReader
    {
        private static IConfigurationRoot config;

        static ConfigurationReader()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string GetValue(string key)
        {
            return config[key];
        }
        public static string GetSectionValue(string section, string key)
        {
            return config.GetSection(section)[key];
        }

        public static int GetIntValue(string section, string key) { 
            var value = config.GetSection(section)[key];
            return int.TryParse(value, out int result) ? result : 0;
        }
    }
}
