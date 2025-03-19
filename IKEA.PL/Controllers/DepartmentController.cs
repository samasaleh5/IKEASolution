using IKEA.BLL.Dto_s.Departments;
using IKEA.BLL.Services.DepartmentServices;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {//service=>departments

        private IDepartmentServices departmentServices;
        private readonly ILogger<DepartmentController> logger;
        private readonly IWebHostEnvironment environment;

        public DepartmentController(IDepartmentServices _departmentServices,ILogger<DepartmentController>_logger,IWebHostEnvironment environment)
        {
                departmentServices = _departmentServices;
                logger = _logger;
                this.environment = environment;
          
        }
        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var Departments = departmentServices.GetAllDepartments();
            if (Departments == null)
            { 
                Departments=new List<DepartmentDto>();
            }
            return View();
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

    }
}
