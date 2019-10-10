using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using AsciiLib;
using System.IO;

namespace AsciiCombiner
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    throw new ArgumentException("too few files specified");
                }
                Console.WriteLine(CombineFiles(args));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // CreateHostBuilder(args).Build().Run();
        }

        public static string CombineFiles(IEnumerable<string> files)
        {
            IAsciiCombiner combiner = new AsciiLib.AsciiCombiner();
            var image = combiner.combineImages(files.Select((f) => File.ReadAllText(f)));
            return image;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
