using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace Roopa.Employee.Rest.Api
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public class MyOptions
        {
            public string conStr { get; set; }
        }

      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                //config.RespectBrowserAcceptHeader = true;
                //config.ReturnHttpNotAcceptable = true;
            }).AddXmlSerializerFormatters();
            services.AddOptions();

            services.Configure<MyOptions>(myOptions =>
            {
                myOptions.conStr = Configuration.GetConnectionString("getconn");
            });

            //string conStr = this.Configuration.GetConnectionString("getconn");

        }

       

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.Run(async (context) =>
            //{
            //    await context.Response
            //    .WriteAsync(Configuration["getconn"]);
            //});
            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
