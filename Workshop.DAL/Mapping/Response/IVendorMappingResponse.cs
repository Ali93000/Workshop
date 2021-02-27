using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Vendor;
using Workshop.Entities.ApiModels.Vendor.Response;

namespace Workshop.DAL.Mapping.Response
{
    public interface IVendorMappingResponse
    {
        VendorsResponse MapFromDBModelToVendorDTOResponse(IEnumerable<W_D_Vendor> vendors);
        VendorResponse MapFromDBModelToVendorDTOResponse(W_D_Vendor vendors);
    }
}
