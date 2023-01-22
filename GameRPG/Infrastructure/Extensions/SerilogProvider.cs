using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace GameRPG.Infrastructure.Extensions
{
    public class SerilogProvider
    {
        public static string Application => "Application";
        public static string CustomerCode => "customerCode";
        public static string Exception => "exception";
        public static string Operation => "operation";

        public static void CreateLogger(string serviceName, IConfiguration config)
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log-.txt")
                .CreateLogger();

            Log.ForContext("application", serviceName)
                .ForContext(Operation, nameof(CreateLogger))
                .Information($"Log iniciado para aplicação:[{serviceName}] da data de: [{DateTime.Now}]");
        }
    }
}
