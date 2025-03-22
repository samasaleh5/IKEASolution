using IKEA.DAL.Models;
using IKEA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Repositories._Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        //return all 
        IEnumerable<T> GetAll(bool withNoTracking = true);
        //return specific department
        T? GetById(int id);
        //return how many row effected (int)
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
