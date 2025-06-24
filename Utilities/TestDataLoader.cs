using System;
using System.IO;
using Newtonsoft.Json;

namespace RestSharpAPIAutomation.Utilities
{
    public static class TestDataLoader
    {
        public static T Load<T>(string fileName) where T : new()
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", fileName);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"Test data file not found: {fullPath}");

            var json = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
