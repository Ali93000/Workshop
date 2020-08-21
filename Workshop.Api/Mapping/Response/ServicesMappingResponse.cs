using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Implementation;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.Entities.ApiModels.Services.Response;

namespace Workshop.Api.Mapping.Response
{
    public class ServicesMappingResponse : IServicesrMappingResponse
    {
        private readonly IServicesMapperConfiguration  _servicesMapperConfiguration;
        public ServicesMappingResponse(IServicesMapperConfiguration  servicesMapperConfiguration)
        {
            this._servicesMapperConfiguration = servicesMapperConfiguration;

        }
        public ServicesResponse mapFromDbToServicesDTO(IEnumerable<W_D_Services> services)
        {
            return _servicesMapperConfiguration.GetMapper().Map<ServicesResponse>(services);
        }

        public ServicesIDResponse mapFromDbToServicesDTO(W_D_Services services)
        {
            return _servicesMapperConfiguration.GetMapper().Map<ServicesIDResponse>(services);
        }
    }
}