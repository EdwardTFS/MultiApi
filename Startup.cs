using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace MultiApi
{
    class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<TestService>().As<ITestService>();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseAuthorization();
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => await context.Response.WriteAsync($"<html><body><h1>MultiApi {version}</h1><a href=\"WeatherForecast\">test data</a></body></html>"));
                endpoints.MapControllers();
            });
        }

    }
}