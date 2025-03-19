using IKEA.BLL.Services.DepartmentServices;
using IKEA.DAL.Persistance.Data;
using IKEA.DAL.Persistance.Repositories.Departments;
using Microsoft.EntityFrameworkCore;

namespace IKEA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Entry Point
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Configure Services
            builder.Services.AddControllersWithViews();

            //get connection from appsetting.json file
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            });

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();

            //not used now old way
            //builder.Services.AddScoped<ApplicationDbContext>();
            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>((service) =>
            //{
            //    var optionbuilder=new DbContextOptionsBuilder<ApplicationDbContext>();
            //    optionbuilder.UseSqlServer("Server=.;Database=IKEA_DB;trusted_Connection=true;TrustedCertificate=true");

            //    var options=optionbuilder.Options;

            //    return options;

            //});
            #endregion



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

           

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
