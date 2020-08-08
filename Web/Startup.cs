using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        /*******************************************************************/
        /* Getting the Configurations from JSON file                       */
        /*******************************************************************/
        //!AhmedShaban: private variable to hold configurations from JSON
        private readonly IConfiguration configurations;
        //!AhmedShaban: Constructor of class
        public Startup(IConfiguration configurations)
        {
            this.configurations = configurations;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //!Ahmedshaban: Add MVC service
            //we will deal with controllers and pages with views
            services.AddControllersWithViews();
            //!AhmedShaban: Add Database context to connect it
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configurations.GetConnectionString("MyPortfolioDB"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //!AhmedShaban: Add static files
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                //The objective here is to open the site by default in the controller home
                endpoints.MapControllerRoute(
                    "defaultRoute",
                    //controller and the action that the controller take
                    "{controller=Home}/{action=Index}/{id?}");
                //according to this scenario, the next step is to creat a home controller
            });
        }
    }
}