using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiSandbox
{
    public class Program
    {
        public class Options
        {
            [Option('v', "Verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }

            public bool ConnectionString { get; internal set; }
        }

        public class ConnectionOptions
        {
            [Option('c', "Connection", Required = false, HelpText = "Set the connection")]
            public bool ConnectionString { get; set; }
        }

        public static int Main(string[] args)
        {
            Parser.Default.ParseArguments<Options, ConnectionOptions>(args)
                  .WithParsed<Options>(o =>
                  {
                      if (o.Verbose)
                      {
                          Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                          Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                      }
                      else
                      {
                          Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                          Console.WriteLine("Quick Start Example!");
                      }

                      Console.WriteLine(o.ConnectionString);
                  });
                  //.WithParsed<ConnectionOptions>(c =>
                  //  {
                  //      if (o.Connection.ToString == "SqlServer")
                  //      {
                  //          Console.WriteLine(o.Connection);
                  //      }
                  //      else
                  //      {
                  //          Console.WriteLine("No SQL connection!");
                  //      }
                  //  });
            if (args.Length > 0)
            {
                Console.WriteLine($"There are : {args.Length} args." );
            }
            else
            {
                Console.WriteLine("No arguments.");
            }

            CreateHostBuilder(args).Build().Run();
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
