using AutoMapper;
using Company.DAL.Contexts;
using Company.DAL.Models;
using Company.DAL.Reposatires.DepartmentRepo;
using Company.DAL.Reposatires.EmployeeRepo;
using Company.DAL.UOW;
using Microsoft.AspNetCore.Identity;
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

            // Add MVC
            builder.Services.AddControllersWithViews();

            // Add DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=demo.db");
                options.UseLazyLoadingProxies();
            });

            // Add Dependency Injection
            builder.Services.AddScoped<IDepartmentRepositries, DepartmentReposatory>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositroy>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddAutoMapper(M => M.AddMaps(typeof(ProjectMapperProfile).Assembly));

            // Add Identity
            builder.Services.AddIdentity<ApplicatiionUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // Add Authentication with Cookie
            builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.EnsureCreated();
                DemoSeed.Seed(db, scope.ServiceProvider.GetRequiredService<UserManager<ApplicatiionUser>>());
            }

            // Use Static Files
            app.UseStaticFiles();

            // Routing
            app.UseRouting();

            // Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Endpoint Routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
