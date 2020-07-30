using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.DTO.Employee
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string EmpSpecialist { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<int> CompCode { get; set; }
        public Nullable<int> BranchCode { get; set; }
    }
}
