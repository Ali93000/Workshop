using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Request;
using Workshop.Entities.ApiModels.Customer;

namespace Workshop.Api.Mapping.Request
{
    public class CustomerReqMappingRequest : ICustomerReqMappingRequest
    {
        private readonly ICustomerMapperConfiguration _customerMapperConfiguration;
        public CustomerReqMappingRequest(ICustomerMapperConfiguration customerMapperConfiguration)
        {
            this._customerMapperConfiguration = customerMapperConfiguration;
        }
        public W_D_Customer MapDBCustomerModelToCustomerReq(CustomerReq customerReq)
        {
            return _customerMapperConfiguration.GetMapper().Map<W_D_Customer>(customerReq);
        }
    }
}