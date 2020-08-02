using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.ApiModels.Employee
{
    public class EmployeeReq
    {
        public int Id { get; set; }
        public string EmpCode { get; set; }
        public string EmpNameAr { get; set; }
        public string EmpNameEn { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string EmpSpecialist { get; set; }
        public string Remarks { get; set; }
    }
}
