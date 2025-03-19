using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Dto_s.Departments
{
    public class DepartmentDetailsDto

    {
        public int Id { get; set; }
        #region Adminstration
        public bool IsDeleted { get; set; } //Soft Delete
        public int CreatedBy { get; set; }
        public DateTime CreateOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        #endregion
        public string Name { get; set; } = null!;//not equal null required
        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public DateOnly CreationDate { get; set; }
    }
}
