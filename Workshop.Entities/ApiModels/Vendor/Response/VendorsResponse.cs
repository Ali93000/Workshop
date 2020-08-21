using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.Vendor;

namespace Workshop.Entities.ApiModels.Vendor
{
    public class VendorsResponse : GenericResponse
    {
        public VendorsResponse()
        {
            VendorsList = new List<VendorDTO>();
        }
        public List<VendorDTO> VendorsList { get; set; }
    }
}
