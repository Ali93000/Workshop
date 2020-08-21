using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.ApiModels.Vendor.Request
{
    public class VendorReq
    {
        public int Id { get; set; }
        public string VendorCode { get; set; }
        public string VerndorNameAr { get; set; }
        public string VerndorNameEn { get; set; }
        public string ResponsibleName { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string VatNo { get; set; }
        public string VatType { get; set; }
        public string VendorAddress { get; set; }
        public string Remarks { get; set; }
    }
}
