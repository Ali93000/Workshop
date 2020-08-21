using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Services.Request;
using Workshop.Entities.ApiModels.Services.Response;
using Workshop.Entities.DTO.Services;

namespace Workshop.Api.Mapping.AutomapperConfiguration.Implementation
{
    public class ServicesMapperConfiguration : IServicesMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<W_D_Services, ServicesDTO>();

                cfg.CreateMap<IEnumerable<W_D_Services>, ServicesResponse>()
                .ForMember(des => des.servicesList, map => map.MapFrom(src => src));

                cfg.CreateMap<ServicesDTO, ServicesResponse>()
                .ForMember(des => des.servicesList, map => map.MapFrom(src => src));

                cfg.CreateMap<W_D_Services, ServicesIDResponse>()
                .ForMember(des => des.servicesId, map => map.MapFrom(src => src));

                cfg.CreateMap<ServicesDTO, ServicesIDResponse>()
                .ForMember(des => des.servicesId, map => map.MapFrom(src => src));

                cfg.CreateMap<ServicesReq, W_D_Services>();
              

            });

            return config.CreateMapper();
        }
    }
}
