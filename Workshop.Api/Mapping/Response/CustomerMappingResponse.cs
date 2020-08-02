using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.Entities.ApiModels.Customer.Response;
using Workshop.Entities.DTO;

namespace Workshop.Api.Mapping.Response
{
    public class CustomerMappingResponse : ICustomerMappingResponse
    {
        private readonly ICustomerMapperConfiguration _customerMapperConfiguration;
        public CustomerMappingResponse(ICustomerMapperConfiguration customerMapperConfiguration)
        {
            this._customerMapperConfiguration = customerMapperConfiguration;
        }
        public CustomersResponse MapCustomerDTOFromDBCustomerModel(IEnumerable<W_D_Customer> DBCustomer)
        {
            return _customerMapperConfiguration.GetMapper().Map<CustomersResponse>(DBCustomer);
        }

        public CustomerResponse MapCustomerDTOFromDBCustomerModel(W_D_Customer DBCustomer)
        {
            return _customerMapperConfiguration.GetMapper().Map<CustomerResponse>(DBCustomer);
        }
    }
}