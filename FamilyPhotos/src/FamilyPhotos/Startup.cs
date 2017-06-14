using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FamilyPhotos.Repository;
using FamilyPhotos.Filters;
using FamilyPhotos.Loggers;

namespace FamilyPhotos
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Ha tesztelni akarjuk az indulás közbeni hibakezelést, akkor ezt például így tehetjük meg
            //throw new Exception("ez itt egy hiba");

            //Azért, hogy minden egyes kérésnél ugyanahhoz a repositoryhoz jussunk, Singleton-ként kell regisztrálnunk.
            //A C# Singleton mintáról részletesen: http://csharpindepth.com/articles/general/singleton.aspx
            services.AddSingleton<PhotoRepository, PhotoRepository>();

            var amCfg = new AutoMapper.MapperConfiguration(
                cfg=>cfg.AddProfile(new ViewModel.MappingProfile())
            );
            var mapper = amCfg.CreateMapper();
            services.AddSingleton(mapper);

            //ELMAH utód az MVC alatt
            services.AddElm(
                //opts =>
                //{
                //    opts.Path = new PathString("/elm");
                //    opts.Filter = (name, level) => level >= LogLevel.Trace;
                //}
                );

            services.AddMvc(o=>
            {
                o.Filters.Add(new MyExceptionFilter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole()
                         .AddDebug(LogLevel.Trace)
                         .AddMyLogger()
                         ;

            //Ha nem csak egyszerű státuszkóddal akarunk válaszolni, hanem 
            //szeretnénk egyszerű információkat adni, akkor például így tudunk
            //400-599 közötti kódokhoz megoldás
            //de csak, ha a például a kivételt előtte kezeltük és a státuszkóddal térünk vissza
            //az action-ből

            //alapértelmezés
            //app.UseStatusCodePages();

            //Különböző beállítási lehetőségek
            //app.UseStatusCodePages("text/plain", "Ez egy hibás kérés, a kód: {0}");
            //app.UseStatusCodePages( async context => 
            //{
            //    context.HttpContext
            //           .Response
            //           .ContentType = "text/plain";

            //    await context.HttpContext
            //                 .Response
            //                 .WriteAsync($"Ez a UseStatusCodePages delegate settings, a kód pedig: {context.HttpContext.Response.StatusCode}");
            //});
            //és még rengeteg beállítási lehetőség: 
            //http://www.talkingdotnet.com/handle-404-error-asp-net-core-mvc-6/

            //Például átirányíthatjuk saját oldalra:
            //app.UseStatusCodePagesWithRedirects("~/Errors/StatusCodePagesWithRedirects/{0}"); //így id-vel kell átvenni
            //app.UseStatusCodePagesWithRedirects("~/Errors/StatusCodePagesWithRedirects?statusCode={0}"); //így meg statusCode-dal

            //Vagy visszaküldjük újrafeldolgozásra, ekkor több információhoz is hozzáférünk
            app.UseStatusCodePagesWithReExecute("/Errors/StatusCodePagesWithReExecute", "?statusCode={0}");

            ////https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            //    //https://docs.microsoft.com/en-us/aspnet/core/client-side/using-browserlink
            //    //app.UseBrowserLink();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");

                ///Also, be aware that once the headers for a response have been sent, 
                ///you can't change the response's status code, nor can any exception 
                ///pages or handlers run.
                ///The response must be completed or the connection aborted.
                ///
                ///Server exception handling
                ///
                ///In addition to the exception handling logic in your app, 
                ///the server hosting your app will perform some exception 
                ///handling.
                ///
                ///If the server catches an exception before the headers have 
                ///been sent it sends a 500 Internal Server Error response with no body.
                ///
                /// If it catches an exception after the headers have been sent, 
                /// it closes the connection. 
                /// 
                /// Requests that are not handled by your app will be handled by 
                /// the server (Kestrel, IIS+K, NGINX+K, Apache+K), and any exception 
                /// that occurs will be handled by the server's exception handling. 
                /// 
                /// Any custom error pages or exception handling middleware or filters 
                /// you have configured for your app will not affect this behavior.
                /// 
                /// Exception filters are good for trapping exceptions that occur within 
                /// MVC actions, but they're not as flexible as error handling middleware. 
                /// Prefer middleware for the general case, and use filters only where you 
                /// need to do error handling differently based on which MVC action was 
                /// chosen.

            }
            else
            {
                //Hibakezelés saját action-nel (middleware-rel): 
                //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling
                //app.UseExceptionHandler("/Errors"); //Ez így az /Errors/Index-re megy
                app.UseExceptionHandler("/Errors/ExceptionHandler");
            }

            //Egyszerű oldal egy rövid mondattal
            //pl.: Status Code: 404; Not Found, illetve, 400-599
            //app.UseStatusCodePages();

            //app.UseStatusCodePagesWithRedirects(); //?
            //app.UseStatusCodePagesWithReExecute();

            //app.UseRuntimeInfoPage(); //???


            //https://www.tutorialspoint.com/asp.net_core/asp.net_core_static_files.htm
            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files
            //app.UseDefaultFiles();
            //app.UseStaticFiles(); //
            //app.UseFileServer(); //Ez az előző kettőt tartalmazza

            //ELMAH  
            //app.UseElmPage();
            //app.UseElmCapture();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
