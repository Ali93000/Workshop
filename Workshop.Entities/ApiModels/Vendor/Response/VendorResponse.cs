using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.Vendor;

namespace Workshop.Entities.ApiModels.Vendor.Response
{
    public class VendorResponse :GenericResponse
    {
        public VendorResponse()
        {
            Vendor = new VendorDTO();
        }
        public VendorDTO Vendor { get; set; }
    }
}
