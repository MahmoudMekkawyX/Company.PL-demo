using Microsoft.AspNetCore.Mvc;
using ompany.BLL.Dto_s.Employee;
using ompany.BLL.services.EmployeeServices;

namespace Company.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        private readonly ILogger<EmployeeController> logger;
        private readonly IWebHostEnvironment environment;

        public EmployeeController(IEmployeeServices employeeServices, ILogger<EmployeeController> logger, IWebHostEnvironment environment)
        {
            this.employeeServices = employeeServices;
            this.logger = logger;
            this.environment = environment;
        }
        public IActionResult Index(string? searchValue)
        {
            IEnumerable<EmployeeDto> employees;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                employees = employeeServices.GetEmployees();
            }
            else
            {
                employees = employeeServices.GetSearchedEmployees(searchValue);
            }

            return View(employees);
        }

        // GET: Employee/Details/5
        public IActionResult Details(int id)
        {
            var employee = employeeServices.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }
        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                employeeServices.CreateEmployee(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = employeeServices.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                employeeServices.UpdateEmployee(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            employeeServices.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
