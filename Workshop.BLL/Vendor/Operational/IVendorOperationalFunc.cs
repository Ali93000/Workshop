using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.ApiModels.Vendor.Request;

namespace Workshop.BLL.Vendor.Operational
{
    public interface IVendorOperationalFunc
    {
        int CreateVendor(VendorReq vendorReq);
        void UpdateVendor(VendorReq vendorReq);
        void DeleteVendor(int id);
    }
}
