using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastProjects.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LastProjects
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = @"Server='(localdb)\MSSQLLocalDB'; Database=SchoolDb; Trusted_Connection=true; ";
            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(connection));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(

                    name: "default",
                    template: "{controller=Student}/{action=index}/{id?}"
                    );
            });


            //app.UseMvcWithDefaultRoute();

            //    app.UseMvc(ConfigureRoutes);

        }

        //private void ConfigureRoutes(IRouteBuilder routeBuilder)
        //{
        //    routeBuilder.MapRoute("Default", "{controler=Student}/{ action = Index}/{id?}");
        //}
    }
}
