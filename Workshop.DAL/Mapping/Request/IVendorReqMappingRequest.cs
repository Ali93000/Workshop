using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Vendor.Request;

namespace Workshop.DAL.Mapping.Request
{
    public interface IVendorReqMappingRequest
    {
        W_D_Vendor MapFromVendorReqToVendorDB(VendorReq vendorReq);
    }
}
