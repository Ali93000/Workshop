using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Customer;
using Workshop.Entities.ApiModels.Customer.Response;
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

                cfg.CreateMap<IEnumerable<W_D_Customer>, CustomersResponse>()
                .ForMember(des => des.CustomersList, map =>
                 map.MapFrom(src => src));
                
                cfg.CreateMap<W_D_Customer, CustomerResponse>()
                .ForMember(des => des.Customer, map =>
                 map.MapFrom(src => src));
            });
            return config.CreateMapper();
        }
    }
}