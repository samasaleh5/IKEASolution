using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Departments
{
    public class Department:ModelBase
    {
        public string Name { get; set; } = null!;//not equal null required
        public string Code { get; set; } = null!;//not equal null required

        public string? Description { get; set; }

        public DateOnly CreationDate { get; set; }





    }
}
