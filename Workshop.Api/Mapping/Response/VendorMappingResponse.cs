using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.Implementation;
using Workshop.Entities.ApiModels.Vendor;
using Workshop.Entities.ApiModels.Vendor.Response;

namespace Workshop.Api.Mapping.Response
{
    public class VendorMappingResponse : IVendorMappingResponse
    {
        private readonly IVendorMapperConfiguration _vendorMapperConfiguration;
        public VendorMappingResponse(IVendorMapperConfiguration  vendorMapperConfiguration)
        {
            this._vendorMapperConfiguration = vendorMapperConfiguration;
        }

        public VendorsResponse MapFromDBModelToVendorDTOResponse(IEnumerable<W_D_Vendor> vendors)
        {
            return _vendorMapperConfiguration.GetMapper().Map<VendorsResponse>(vendors);
        }

        public VendorResponse MapFromDBModelToVendorDTOResponse(W_D_Vendor vendors)
        {
            return _vendorMapperConfiguration.GetMapper().Map<VendorResponse>(vendors);
        }
    }
}