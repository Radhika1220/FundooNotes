// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Radhika"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using NLog.Web;

    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main method and has as create host builder
        /// </summary>
        /// <param name="args">string args</param>
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("Nlog.Config").GetCurrentClassLogger();
            logger.Debug("Main function");
            CreateHostBuilder(args).Build().Run();
            NLog.LogManager.Shutdown(); 
        }

        /// <summary>
        /// create host builder functionality
        /// </summary>
        /// <param name="args"> string as args </param>
        /// <returns> returning as IHost builder </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
 
                }).ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Information);
                }).UseNLog();


    }
}
