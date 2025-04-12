using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Repositories.Employees
{
    public class EmployeeRepository : _Generic.GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeeRepository(ApplicationDbContext context):base(context) 
        {
            dbContext = context;
        }

    }
}
