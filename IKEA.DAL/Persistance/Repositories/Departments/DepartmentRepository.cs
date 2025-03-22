using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistance.Data;
using IKEA.DAL.Persistance.Repositories.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Repositories.Departments
{
    public class DepartmentRepository : _Generic.GenericRepository<Department>, IDepartmentRepository
    {
      
            private readonly ApplicationDbContext dbContext;
            public DepartmentRepository(ApplicationDbContext context) : base(context)
            {
                dbContext = context;
            }

        

    }
}
