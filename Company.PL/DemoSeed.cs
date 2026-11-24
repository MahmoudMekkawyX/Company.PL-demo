using Company.DAL.Contexts;
using Company.DAL.Models.Department;
using Company.DAL.Models.shared;
using Company.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace Company.PL
{
    public static class DemoSeed
    {
        public static void Seed(ApplicationDbContext db, UserManager<ApplicatiionUser> users)
        {
            if (users.FindByEmailAsync("demo@example.com").Result == null)
                users.CreateAsync(new ApplicatiionUser { UserName = "demo", Email = "demo@example.com", FirstName = "Demo", LastName = "User" }, "Demo@123").Wait();
            if (db.Departments.Any()) return;
            var now = DateTime.Now;
            var depts = new[]
            {
                new Department { Name = "Engineering", Code = "ENG-01", Description = "Product development", createdOn = now, LastModifiedOn = now },
                new Department { Name = "Human Resources", Code = "HR-01", Description = "Hiring and people operations", createdOn = now, LastModifiedOn = now },
                new Department { Name = "Finance", Code = "FIN-01", Description = "Accounting and payroll", createdOn = now, LastModifiedOn = now },
                new Department { Name = "Support", Code = "SUP-01", Description = "Customer support", createdOn = now, LastModifiedOn = now },
            };
            db.Departments.AddRange(depts);
            db.SaveChanges();
            var people = new (string n, int a, string ad, decimal s, Gender g, EmployeeType t, int d)[]
            {
                ("Omar Hassan", 29, "12 Nile St, Cairo", 32000, Gender.Male, EmployeeType.FullTime, 0),
                ("Salma Adel", 26, "5 Garden Rd, Giza", 28000, Gender.Female, EmployeeType.FullTime, 0),
                ("Youssef Nabil", 31, "40 Lake Ave, Alexandria", 36000, Gender.Male, EmployeeType.FullTime, 0),
                ("Mona Fathy", 34, "8 Park Ln, Cairo", 30000, Gender.Female, EmployeeType.FullTime, 1),
                ("Karim Samir", 27, "21 Palm St, Giza", 18000, Gender.Male, EmployeeType.PartTime, 1),
                ("Laila Mansour", 38, "3 Hill Rd, Cairo", 41000, Gender.Female, EmployeeType.FullTime, 2),
                ("Tarek Ezz", 45, "17 River St, Cairo", 45000, Gender.Male, EmployeeType.FullTime, 2),
                ("Dina Reda", 24, "9 Sun St, Giza", 15000, Gender.Female, EmployeeType.PartTime, 3),
                ("Hady Kamal", 28, "30 Rose Ave, Cairo", 20000, Gender.Male, EmployeeType.FullTime, 3),
                ("Nour Ashraf", 25, "14 Oak Rd, Alexandria", 19000, Gender.Female, EmployeeType.FullTime, 3),
            };
            int i = 0;
            foreach (var p in people)
            {
                i++;
                db.Employees.Add(new Employee
                {
                    Name = p.n, Age = p.a, Address = p.ad, Salary = p.s, Gender = p.g, EmployeeType = p.t,
                    Email = $"employee{i}@example.com", PhoneNumber = $"010000000{i:00}",
                    HiringDate = DateOnly.FromDateTime(now.AddMonths(-3 * i)), IsActive = true,
                    DepartmentId = depts[p.d].Id, createdOn = now, LastModifiedOn = now
                });
            }
            db.SaveChanges();
        }
    }
}
