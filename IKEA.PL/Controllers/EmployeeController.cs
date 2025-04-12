using IKEA.BLL.Dto_s.Departments;
using IKEA.BLL.Dto_s.Employees;
using IKEA.BLL.Services.DepartmentServices;
using IKEA.BLL.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class EmployeeController : Controller
    {
        #region Services DI

        private readonly IEmployeeServices EmployeeServices;
        private readonly ILogger<EmployeeController> logger;
        private readonly IWebHostEnvironment environment;

        public EmployeeController(IEmployeeServices employeeServices,ILogger<EmployeeController> logger,IWebHostEnvironment environment)
        {
            EmployeeServices = employeeServices;
            this.logger = logger;
            this.environment = environment;
        }
        #endregion

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var Employees=EmployeeServices.GetAllEmployees();
            return View(Employees);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto employeeDto)
        {
            //serverside validation
            if (!ModelState.IsValid)
                return View(employeeDto);
            var Message = string.Empty;

            try
            {
                var Result = EmployeeServices.CreateEmployee(employeeDto);
                if (Result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    Message = "Employee is not Created";
                  

            }
            catch (Exception ex)
            {
                //1.Log Exception Kestral
                logger.LogError(ex, ex.Message);

                //2.Set Default Message User
                if (environment.IsDevelopment())
                    Message = ex.Message;
                else
                    Message = "An Error Effect At The Creation Operator";
            }
            ModelState.AddModelError(string.Empty, Message);
            return View(employeeDto);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = EmployeeServices.GetEmployeeById(id.Value);

            if (employee is null)
                return NotFound();

            return View(employee);

        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();

            var Employee = EmployeeServices.GetEmployeeById(id.Value);

            if (Employee is null)
                return NotFound();

            var MappedEmployee = new UpdateEmployeeDto()
            {
                Id = Employee.Id,
                Name= Employee.Name,
                Age= Employee.Age,
                Address= Employee.Address,
                HiringDate= Employee.HiringDate,
                Salary= Employee.Salary,
                Gender= Employee.Gender,
                EmployeeType= Employee.EmployeeType,
                IsActive= Employee.IsActive,
 
            };

            return View(MappedEmployee);

        }

        [HttpPost]
        public IActionResult Edit(UpdateEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return View(employeeDto);

            var Message = string.Empty;
            try
            {
                var Result = EmployeeServices.UpdateEmployee(employeeDto);

                if (Result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    Message = "Employee is Not Updated";

            }
            catch (Exception ex)
            {
                //1.log exceptions
                logger.LogError(ex, ex.Message);

                //2.Set Message
                Message = environment.IsDevelopment() ? ex.Message : "An Error has been occurred during Update The Employee!";
            }

            ModelState.AddModelError(string.Empty, Message);
            return View(employeeDto);
        }

        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var Employee = EmployeeServices.GetEmployeeById(id.Value);

            if (Employee is null)
                return NotFound();

            return View(Employee);
        }

        [HttpPost]
        public IActionResult Delete(int EmpId)
        {
            var Message = string.Empty;
            try
            {
                var IsDeleted = EmployeeServices.DeleteEmployee(EmpId);

                if (IsDeleted)
                    return RedirectToAction(nameof(Index));

                Message = "Employee is not Deleted";
            }
            catch (Exception ex)
            {
                //1.log exceptions
                logger.LogError(ex, ex.Message);

                //2.Set Message
                Message = environment.IsDevelopment() ? ex.Message : "An Error has been occurred during Delete The Employee!";
            }

            ModelState.AddModelError(string.Empty, Message);
            return RedirectToAction(nameof(Delete), new { id = EmpId });
        }

        #endregion
    }
}
