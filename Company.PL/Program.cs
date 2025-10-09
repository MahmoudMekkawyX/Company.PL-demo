using Company.BLL.Services;
using Company.DAL.Contexts;
using Company.DAL.Reposatires.DepartmentRepo;
using Microsoft.EntityFrameworkCore;
using ompany.BLL.services;

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
