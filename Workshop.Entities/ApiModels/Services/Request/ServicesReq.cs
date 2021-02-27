using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.ApiModels.Services.Request
{
   public class ServicesReq
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
    }
}
