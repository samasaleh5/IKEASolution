using IKEA.BLL.Dto_s.Departments;
using IKEA.BLL.Dto_s.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.EmployeeServices
{
    public interface IEmployeeServices
    {
        //DTO: DataTransfer Object

        IEnumerable<EmployeeDto> GetAllEmployees();

        EmployeeDetailsDto? GetEmployeeById(int id);

        int CreateEmployee(CreateEmployeeDto employeeDto);

        int UpdateEmployee(UpdateEmployeeDto employeeDto);

        bool DeleteEmployee(int id);
    }
}
