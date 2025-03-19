using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Dto_s.Departments
{
    public class UpdatedDepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;//not equal null required
        public string Code { get; set; } = null!;//not equal null required

        public string? Description { get; set; }

        public DateOnly CreationDate { get; set; }

    }
}
