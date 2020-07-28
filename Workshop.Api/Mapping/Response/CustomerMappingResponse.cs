using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
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
        public IEnumerable<CustomerDTO> MapCustomerDTOFromDBCustomerModel(IEnumerable<W_D_Customer> DBCustomer)
        {
            return _customerMapperConfiguration.GetMapper().Map<List<CustomerDTO>>(DBCustomer);
        }

        public CustomerDTO MapCustomerDTOFromDBCustomerModel(W_D_Customer DBCustomer)
        {
            return _customerMapperConfiguration.GetMapper().Map<CustomerDTO>(DBCustomer);
        }
    }
}