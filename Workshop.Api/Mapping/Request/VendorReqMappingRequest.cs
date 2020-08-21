using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Request;
using Workshop.Entities.ApiModels.Vendor.Request;

namespace Workshop.Api.Mapping.Request
{
    public class VendorReqMappingRequest : IVendorReqMappingRequest
    {
        private readonly IVendorMapperConfiguration _vendorMapperConfiguration;
        public VendorReqMappingRequest(IVendorMapperConfiguration vendorMapperConfiguration)
        {
            this._vendorMapperConfiguration = vendorMapperConfiguration;
        }

        public W_D_Vendor MapFromVendorReqToVendorDB(VendorReq vendorReq)
        {
            return _vendorMapperConfiguration.GetMapper().Map<W_D_Vendor>(vendorReq);
        }
    }
}