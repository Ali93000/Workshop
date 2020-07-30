using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.DTO;
using Workshop.Entities.DTO.Employee;

namespace Workshop.BLL.Employee.Enquiry
{
    public interface IEmployeeEnquiryFunc
    {
        IEnumerable<EmployeeDTO> GetAllEmployee();
        EmployeeDTO GetEmployeeById(int id);
    }
}
