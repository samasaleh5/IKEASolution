using IKEA.DAL.Persistance.Repositories.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.DepartmentServices
{
    public class DepartmentServices
    {
        //controller=>service=>repository=>context=>options
        //use repository to encapsulate layer DAL
         //repository
        private IDepartmentRepository Repository;

        public DepartmentServices(IDepartmentRepository _repository)
        {
            Repository = _repository;
        }
        //implementation of services
    }
}
