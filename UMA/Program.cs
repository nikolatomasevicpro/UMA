using Microsoft.Extensions.Configuration;
using System;

namespace UMA
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var config = configuration.GetSection(nameof(AppConfig)).Get<AppConfig>();
        }
    }
}
