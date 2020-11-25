using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.EventLog;

namespace Stnc.CMS.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                // clear default logging providers
                //logging.ClearProviders();

                //// add built-in providers manually, as needed 
                //logging.AddConsole();
                //logging.AddDebug();
                //logging.AddEventLog();
                //logging.AddEventSourceLogger();
                //logging.AddTraceSource(sourceSwitchName);
            })
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
