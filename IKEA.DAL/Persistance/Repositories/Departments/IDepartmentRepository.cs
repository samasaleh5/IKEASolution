using IKEA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Repositories.Departments
{//5 main fuction
    public interface IDepartmentRepository
    {
        //return all departments
        IEnumerable<Department> GetAll(bool withNoTracking = true);
        //return specific department
        Department? GetById(int id);
        //return how many row effected (int)
        int Add(Department department);
        int Update(Department department);
        int Delete(Department department);

    }
}
