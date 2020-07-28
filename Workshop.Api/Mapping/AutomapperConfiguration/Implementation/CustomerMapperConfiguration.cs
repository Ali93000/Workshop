using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Customer;
using Workshop.Entities.DTO;

namespace Workshop.Api.Mapping.AutomapperConfiguration.Implementation
{
    public class CustomerMapperConfiguration : ICustomerMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<W_D_Customer, CustomerDTO>();

                cfg.CreateMap<CustomerReq, W_D_Customer>();
            });
            return config.CreateMapper();
        }
    }
}