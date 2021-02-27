using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Request;
using Workshop.Entities.ApiModels.Services.Request;

namespace Workshop.Api.Mapping.Request
{
    public class ServicesReqMappingRequest : IServicesReqMappingRequest
    {
        private readonly IServicesMapperConfiguration _servicesMapperConfiguration;
        public ServicesReqMappingRequest(IServicesMapperConfiguration servicesMapperConfiguration)
        {
            this._servicesMapperConfiguration = servicesMapperConfiguration;
        }
        public W_D_Services mapFromSevicesReqToMapDB(ServicesReq servicesReq)
        {
            return _servicesMapperConfiguration.GetMapper().Map<W_D_Services>(servicesReq);
        }
    }
}