using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ompany.BLL.Dto_s.DepartmentDto_s;
using ompany.BLL.Dto_s.Employee;
using ompany.BLL.services.DepartmentServices;
using ompany.BLL.services.EmployeeServices;

namespace Company.PL.Controllers
{
    [Authorize]
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
        // GET: department/Details/5
        public IActionResult Details(int id)
        {
            var employee = departmentServices.GetDepartmentById(id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }
        // GET: department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateDepartmentDto model)
        {
            if (ModelState.IsValid)
            {
                departmentServices.AddDepartment(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        // GET: Department/Edit/5
        public IActionResult Edit(int id)
        {
            var deptDetails = departmentServices.GetDepartmentById(id); // يرجع DepartmentDetailsDto
            if (deptDetails == null)
                return NotFound();

            // تحويل DepartmentDetailsDto → UpdatedDepoartmentDto
            var updateModel = new UpdatedDepoartmentDto
            {
                Id = deptDetails.Id,
                Code = deptDetails.Code,
                Name = deptDetails.Name,
                Description = deptDetails.Description
            };

            return View(updateModel);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdatedDepoartmentDto model)
        {
            if (ModelState.IsValid)
            {
                var result = departmentServices.UpdateDepartment(model);
                if (result > 0)
                {
                    TempData["SuccessMessage"] = "Department updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Update failed. Please try again.");
                }
            }

            return View(model);
        }


        // POST: department/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            departmentServices.DeleteDepartment(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
