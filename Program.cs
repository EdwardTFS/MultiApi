using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MultiApi
{
    class Program
    {
        async static Task Main(string[] args)
        {
            // var builder = WebApplication.CreateBuilder(args);

            // // Add services to the container.

            // builder.Services.AddControllers();
         
            // var app = builder.Build();

            

            // app.UseAuthorization();

            // app.MapControllers();
            // app.MapGet("/", () => "Root");
            // await app.RunAsync();

           var host = CreateHostBuilder(args).Build();
           await host.RunAsync();


        }
    
      static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

}

