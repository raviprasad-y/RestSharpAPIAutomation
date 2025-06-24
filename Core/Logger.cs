using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Core
{
    public static class Logger
    {
        public static void InitLogger()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("serilog.json", optional: false, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
        }

        public static void Info(string message) => Log.Information(message);
        public static void Warn(string message) => Log.Warning(message);
        public static void Error(string message) => Log.Error(message);
        public static void Fatal(string message) => Log.Fatal(message);
    }
}

