using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRPG
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args);
            host.Run();
        }

        private static IWebHost CreateHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                       .CaptureStartupErrors(true)
                       .UseStartup<Startup>()
                       .Build();
    }
}
