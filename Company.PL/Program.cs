using AutoMapper;
using Company.DAL.Contexts;
using Company.DAL.Reposatires.DepartmentRepo;
using Company.DAL.Reposatires.EmployeeRepo;
using Microsoft.EntityFrameworkCore;
using ompany.BLL.Commen;
using ompany.BLL.services.DepartmentServices;
using ompany.BLL.services.EmployeeServices;

namespace Company.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDepartmentRepositries, DepartmentReposatory>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositroy>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddAutoMapper(M => M.AddMaps(typeof(ProjectMapperProfile).Assembly));

            var app = builder.Build();

            app.UseRouting();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
