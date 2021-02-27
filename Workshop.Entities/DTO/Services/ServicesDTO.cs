using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.DTO.Services
{
  public class ServicesDTO
    {
        public int Id { get; set; }
        public string CodeServices { get; set; }
        public string DescriptionServicesA__DescriptionServicesA__DescriptionServicesA { get; set; }
        public string DescriptionServicesE { get; set; }
        public Nullable<decimal> ServicesPrice { get; set; }
        public Nullable<decimal> LowestSellingPrice { get; set; }
        public string VatType { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Remark { get; set; }
        public string CreateAt__CreateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<int> CompanyCode { get; set; }
        public Nullable<int> BranchCode { get; set; }
    }
}
