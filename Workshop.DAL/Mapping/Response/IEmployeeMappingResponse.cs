using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Employee;
using Workshop.Entities.DTO.Employee;

namespace Workshop.DAL.Mapping.Response
{
    public interface IEmployeeMappingResponse
    {
        IEnumerable<EmployeeDTO> MapEmployeeDBModelToEmployeeDTO(IEnumerable<W_D_Employee> employees);
        EmployeeDTO MapEmployeeDBModelToEmployeeDTO(W_D_Employee employee);
        W_D_Employee MapEmployeeReqToDBModel(EmployeeReq employeeReq);
    }
}
