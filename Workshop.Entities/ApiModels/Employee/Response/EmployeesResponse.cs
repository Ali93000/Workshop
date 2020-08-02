using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.Employee;

namespace Workshop.Entities.ApiModels.Employee.Response
{
    public class EmployeesResponse : GenericResponse
    {
        public EmployeesResponse()
        {
            EmployeesList = new List<EmployeeDTO>();
        }
        public List<EmployeeDTO> EmployeesList { get; set; }
    }
}
