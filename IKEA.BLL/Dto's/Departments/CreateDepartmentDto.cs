using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Dto_s.Departments
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage = "Name is Required!!")]
        public string Name { get; set; } = null!;//not equal null required

        [Required(ErrorMessage ="Code is Required!!")]
        public string Code { get; set; } = null!;//not equal null required

        public string? Description { get; set; }

        [Display(Name ="Date Of Creation")]
        public DateOnly CreationDate { get; set; }

    }
}
