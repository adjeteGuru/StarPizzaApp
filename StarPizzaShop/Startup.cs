using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarPizzaShop.DataAccess;
using StarPizzaShop.DataAccess.Contracts;
using StarPizzaShop.Database;
using StarPizzaShop.Services;

namespace StarPizzaShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // connection string for the dbcontext
            services.AddDbContext<StarPizzaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("StarPizzaDB"));
            }
            );

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<StarPizzaContext>();            

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = false;
            });
            
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IAddressRepo, AddressRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IMenuRepo, MenuRepo>();

            //lightweight stateless services
            services.AddTransient<IMailService, LocalMailService>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
