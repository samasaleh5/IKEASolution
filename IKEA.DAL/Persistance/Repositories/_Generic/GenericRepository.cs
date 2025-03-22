using IKEA.DAL.Models;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Repositories._Generic
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private readonly ApplicationDbContext dbContext;
        public GenericRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IEnumerable<T> GetAll(bool withNoTracking = true)
        {
            if (withNoTracking)
                return dbContext.Departments.Where(D => D.IsDeleted == false).AsNoTracking().ToList();

            return dbContext.Departments.Where(D => D.IsDeleted == false).ToList();
        }

        public Department? GetById(int id)
        {
            var Department = dbContext.Departments.Find(id);
            //var Department = dbContext.Departments.Local.FirstOrDefault(D => D.Id == id);
            //  if(Department == null)
            //      Department=dbContext.Departments.FirstOrDefault(D=>D.Id == id);

            return Department;

        }
        public int Add(Department department)
        {
            dbContext.Departments.Add(department);
            return dbContext.SaveChanges();
        }

        public int Update(Department department)
        {
            dbContext.Departments.Update(department);
            return dbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
            #region SoftDelete
            department.IsDeleted = true;
            dbContext.Departments.Update(department);
            return dbContext.SaveChanges();
            #endregion 

            #region hard Delete
            //dbContext.Departments.Remove(department);
            //return dbContext.SaveChanges();
            #endregion
        }
    }
}
