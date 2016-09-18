using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Preduzece.TimeTracker
{
    public sealed class Program
    {
        private const string HostingJsonFileName = "hosting.json";

        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(HostingJsonFileName, optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel(
                    options =>
                    {
                        // TODO: for Kestrel to serve HTTPS, a certificate is required
                        //options.UseHttps()
                        // Do not add the Server HTTP header when using the Kestrel Web Server.
                        options.AddServerHeader = false;
                    })
                // $Start-WebServer-IIS$
                .UseIISIntegration()
                // $End-WebServer-IIS$
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
