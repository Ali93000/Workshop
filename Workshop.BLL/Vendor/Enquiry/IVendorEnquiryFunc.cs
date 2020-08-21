using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.ApiModels.Vendor;
using Workshop.Entities.ApiModels.Vendor.Response;

namespace Workshop.BLL.Vendor.Enquiry
{
    public interface IVendorEnquiryFunc
    {
        VendorsResponse GetAllVendor();
        VendorResponse GetVendorById(int id);
    }
}
