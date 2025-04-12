using IKEA.BLL.Dto_s.Departments;
using IKEA.BLL.Services.DepartmentServices;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {//service=>departments
        #region Services DI
        private IDepartmentServices departmentServices;
        private readonly ILogger<DepartmentController> logger;
        private readonly IWebHostEnvironment environment;

        public DepartmentController(IDepartmentServices _departmentServices,ILogger<DepartmentController>_logger,IWebHostEnvironment environment)
        {
                departmentServices = _departmentServices;
                logger = _logger;
                this.environment = environment;
          
        }
        #endregion

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var Departments = departmentServices.GetAllDepartments();
            if (Departments == null)
            { 
                Departments=new List<DepartmentDto>();
            }
            return View(Departments);
        }

        #endregion

        #region Details

        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = departmentServices.GetDepartmentById(id.Value);

            if(department is null)
                return NotFound();

         return View(department);
                
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto departmentDto)
        {
            //serverside validation
            if (!ModelState.IsValid)
                return View(departmentDto);

            var Message = string.Empty;

            try
            {
                var Result = departmentServices.CreateDepartment(departmentDto);
                if (Result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    Message = "Department is not Created";
                    ModelState.AddModelError(string.Empty, Message);
                    return View(departmentDto);
                }

            }
            catch (Exception ex)
            {
                //1.Log Exception Kestral
                logger.LogError(ex, ex.Message);

                //2.Set Default Message User
                if (environment.IsDevelopment())
                {
                    Message = ex.Message;
                    ModelState.AddModelError(string.Empty, Message);
                    return View(departmentDto);
                }
                else
                {
                    Message = "An Error Effect At The Creation Operator";
                    ModelState.AddModelError(string.Empty, Message);
                    return View(departmentDto);

                }

            }

        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id is null)
                return BadRequest();

            var Department=departmentServices.GetDepartmentById(id.Value);

            if(Department is null)
                return NotFound();

            var MappedDepartment = new UpdatedDepartmentDto()
            {
                Id = Department.Id,
                Name = Department.Name,
                Code = Department.Code,
                Description = Department.Description,
                CreationDate = Department.CreationDate,
            };

            return View(MappedDepartment);

        }

        [HttpPost]
        public IActionResult Edit(UpdatedDepartmentDto departmentDto)
        {
            if(!ModelState.IsValid)
                return View(departmentDto);

            var Message = string.Empty;
            try
            {
                var Result = departmentServices.UpdateDepartment(departmentDto);

                if (Result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    Message = "Department is Not Updated";

            }
            catch (Exception ex)
            {
                //1.log exceptions
                logger.LogError(ex,ex.Message);

                //2.Set Message
                Message = environment.IsDevelopment() ? ex.Message : "An Error has been occurred during Update The Department!";
            }

            ModelState.AddModelError(string.Empty, Message);
            return View(departmentDto);
        }

        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var Department=departmentServices.GetDepartmentById(id.Value);

            if(Department is null)
                return NotFound();

            return View(Department);
        }

        [HttpPost]
        public IActionResult Delete(int DeptId)
        {
            var Message = string.Empty;
            try
            {
                var IsDeleted = departmentServices.DeleteDepartment(DeptId);

                if (IsDeleted)
                    return RedirectToAction(nameof(Index));

                Message = "Department is not Deleted";
            }
            catch (Exception ex)
            {
                //1.log exceptions
                logger.LogError(ex, ex.Message);

                //2.Set Message
                Message = environment.IsDevelopment() ? ex.Message : "An Error has been occurred during Delete The Department!";
            }

            ModelState.AddModelError(string.Empty,Message);
            return RedirectToAction(nameof(Delete), new {id= DeptId});
        }

        #endregion

    }
}
