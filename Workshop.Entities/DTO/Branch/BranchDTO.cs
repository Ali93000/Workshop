using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.DTO.Branch
{
    public class BranchDTO
    {
        public int BraCode { get; set; }
        public Nullable<int> CompCode { get; set; }
        public string CompName { get; set; }
        public string BraDesAr { get; set; }
        public string BraDesEn { get; set; }
        public string City { get; set; }
        public string BraAddress { get; set; }
        public string BraTel { get; set; }
        public string BraTel2 { get; set; }
        public string BraFax { get; set; }
        public string BraEmail { get; set; }
        public string BranchManager { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
