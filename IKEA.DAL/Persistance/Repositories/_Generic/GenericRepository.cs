﻿using IKEA.DAL.Models;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Repositories._Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private readonly ApplicationDbContext dbContext;
        public GenericRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IEnumerable<T> GetAll(bool withNoTracking = true)
        {
            if (withNoTracking)
                return dbContext.Set<T>().Where(D => D.IsDeleted == false).AsNoTracking().ToList();

            return dbContext.Set<T>().Where(D => D.IsDeleted == false).ToList();
        }

        public T? GetById(int id)
        {
            var item = dbContext.Set<T>().Find(id);
            //var item = dbContext.Set<T>().Local.FirstOrDefault(D => D.Id == id);
            //  if(Department == null)
            //      item=dbContext.Set<T>().FirstOrDefault(D=>D.Id == id);

            return item;

        }
        public int Add(T item)
        {
            dbContext.Set<T>().Add(item);
            return dbContext.SaveChanges();
        }

        public int Update(T item)
        {
            dbContext.Set<T>().Update(item);
            return dbContext.SaveChanges();
        }

        public int Delete(T item)
        {
            #region SoftDelete
            item.IsDeleted = true;
            dbContext.Set<T>().Update(item);
            return dbContext.SaveChanges();
            #endregion 

            #region hard Delete
            //dbContext.Set<T>().Remove(item);
            //return dbContext.SaveChanges();
            #endregion
        }
    }
}
