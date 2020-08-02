using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Employee;
using Workshop.Entities.ApiModels.Employee.Response;
using Workshop.Entities.DTO.Employee;

namespace Workshop.DAL.Mapping.Response
{
    public interface IEmployeeMappingResponse
    {
        EmployeesResponse MapEmployeeDBModelToEmployeeDTO(IEnumerable<W_D_Employee> employees);
        EmployeeResponse MapEmployeeDBModelToEmployeeDTO(W_D_Employee employee);
    }
}
