using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Employee;

namespace Workshop.DAL.Mapping.Request
{
    public interface IEmployeeReqMappingRequest
    {
        W_D_Employee MapEmployeeReqToDBModel(EmployeeReq employeeReq);
    }
}
