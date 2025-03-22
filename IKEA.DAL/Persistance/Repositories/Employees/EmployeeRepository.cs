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
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeeRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IEnumerable<Employee> GetAll(bool withNoTracking = true)
        {
            if (withNoTracking)
                return dbContext.Employees.Where(D => D.IsDeleted == false).AsNoTracking().ToList();

            return dbContext.Employees.Where(D => D.IsDeleted == false).ToList();
        }

        public Employee? GetById(int id)
        {
            var Employee = dbContext.Employees.Find(id);
            //var Employee = dbContext.Employees.Local.FirstOrDefault(D => D.Id == id);
            //  if(Employee == null)
            //      Employee=dbContext.Employees.FirstOrDefault(D=>D.Id == id);

            return Employee;

        }
        public int Add(Employee employee)
        {
            dbContext.Employees.Add(employee);
            return dbContext.SaveChanges();
        }

        public int Update(Employee employee)
        {
            dbContext.Employees.Update(employee);
            return dbContext.SaveChanges();
        }

        public int Delete(Employee employee)
        {
            #region SoftDelete
            employee.IsDeleted = true;
            dbContext.Employees.Update(employee);
            return dbContext.SaveChanges();
            #endregion 

            #region hard Delete
            //dbContext.Employees.Remove(employee);
            //return dbContext.SaveChanges();
            #endregion
        }
    }
}
