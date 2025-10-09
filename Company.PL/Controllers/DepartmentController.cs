using Microsoft.AspNetCore.Mvc;
using ompany.BLL.services;

namespace Company.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices departmentServices;

        public DepartmentController(IDepartmentServices departmentServices)
        {
            this.departmentServices = departmentServices;
        }

        public IActionResult Index()
        {
            var depts = departmentServices.GetDepartments();
            return View(depts);
        }
    }
}
