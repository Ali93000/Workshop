using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Employee;

namespace Workshop.BLL.Employee.Operational
{
    public interface IEmployeeOperationaFunc
    {
        int CreateEmployee(EmployeeReq employeeReq);
        void UpdateEmployee(EmployeeReq employeeReq);
        void DeleteEmployee(int id);
    }
}
