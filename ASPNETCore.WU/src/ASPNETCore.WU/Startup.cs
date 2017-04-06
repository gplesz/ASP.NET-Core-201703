using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ASPNETCore.WU.Repositories;
using Microsoft.Extensions.Configuration;


/// <summary>
/// Application starting
/// Startup class
/// Configure services
/// Configure method (Middle ware components, middleware pipeline)
/// 
/// </summary>



namespace ASPNETCore.WU
{
    public class Startup
    {
        //private readonly IConfiguration Configuration;

        //public Startup()
        //{
        //    var builder = new ConfigurationBuilder()
        //                        .AddJsonFile("appsettings.json");
        //    Configuration = builder.Build();
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddTransient<ICourseRepository, CourseMockRepository>();
            services.AddSingleton<ICourseRepository, CourseMockRepository>();
            //Ahhoz, hogy MVC-nk legyen, kell egy ilyen
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }


            //var message = Configuration["message"];
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});


            //app.UseMvc( 
            //    config=> {
            //        config.MapRoute(
            //            name: "Default", 
            //            template: "{controller}/{action}/{id?}", 
            //            defaults: new {
            //                controller = "Home",
            //                action = "Index"
            //        });
            //    }
            //);

            app.UseStatusCodePages(); //Adds a StatusCodePages middleware with a default response handler that checks for responses with status codes between 400 and 599 that do not have a body.
            app.UseStaticFiles(); //Enables static file serving for the current request path

            app.UseMvcWithDefaultRoute();
        }
    }
}
