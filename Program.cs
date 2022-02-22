using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MultiApi
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
         
            var app = builder.Build();

            

            app.UseAuthorization();

            app.MapControllers();
            app.MapGet("/", () => "Root");
            await app.RunAsync();

        }
    }

}

