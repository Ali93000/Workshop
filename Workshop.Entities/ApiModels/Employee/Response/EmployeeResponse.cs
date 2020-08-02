using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.Employee;

namespace Workshop.Entities.ApiModels.Employee.Response
{
    public class EmployeeResponse : GenericResponse 
    {
        public EmployeeResponse()
        {
            Employee = new EmployeeDTO();
        }
        public EmployeeDTO Employee { get; set; }
    }
}
