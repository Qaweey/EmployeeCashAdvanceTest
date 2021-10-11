using EmployeeCashAdvance.Dapper.DapperRepository;
using EmployeeCashAdvance.Dapper.Interface;
using EmployeeCashAdvance.EntityFrameWorkCore.Repositories;
using EmployeeCashAdvanceApp.Contract.Interface;
using EmployeeCashAdvanceApp.Domain.Models;
using EmployeeCashAdvanceApp.Domain.Shared.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCashAdvance.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static Dictionary<string, string> MySettings { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            MySettings = Configuration.GetSection("MySettings").GetChildren()
                                                             .ToDictionary(s => s.Key, s => s.Value);

            Settings.Initiate(MySettings);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Constants.DB_CONNECTION));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IEmployeeDetails, EmployeeDetailsRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();


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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=CashAdvanceForm}/{id?}");
            });
        }
    }
}
