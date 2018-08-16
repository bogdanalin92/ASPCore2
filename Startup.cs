using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCore2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASPCore2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                                IHostingEnvironment env,
                                IGreeter greeter,
                                ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                var greet = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync($"Not Found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routebuilder)
        {
            // /Home/Index

            routebuilder.MapRoute("Default","{controller=Home}/{action=Index}/{id?}");
        }
    }
}

//Middleware 
 // app.Use(next => {
            //     return async context => {
            //         logger.LogInformation("Request incoming");
            //         if(context.Request.Path.StartsWithSegments("/home")){
            //             await context.Response.WriteAsync("Hello from home!");
            //         }
            //         await next(context);
            //     };
            // });

            // app.UseWelcomePage( new WelcomePageOptions{
            //     Path="/wp"
            // });