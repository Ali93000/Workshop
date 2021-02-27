using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Vendor;
using Workshop.Entities.ApiModels.Vendor.Request;
using Workshop.Entities.ApiModels.Vendor.Response;
using Workshop.Entities.DTO.Vendor;

namespace Workshop.Api.Mapping.AutomapperConfiguration.Implementation
{
    public class VendorMapperConfiguration : IVendorMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<W_D_Vendor, VendorDTO>();

                cfg.CreateMap<IEnumerable<W_D_Vendor>, VendorsResponse>()
                .ForMember(des => des.VendorsList, map =>
                map.MapFrom(src => src));

                cfg.CreateMap<VendorDTO, VendorsResponse>()
                .ForMember(des => des.VendorsList, map =>
                map.MapFrom(src => src));

                cfg.CreateMap<VendorReq, W_D_Vendor>();


                cfg.CreateMap<W_D_Vendor, VendorResponse>()
                .ForMember(des => des.Vendor, map =>
                map.MapFrom(src => src));

                cfg.CreateMap<VendorDTO, VendorResponse>()
                .ForMember(des => des.Vendor, map =>
                map.MapFrom(src => src));
            });
            return config.CreateMapper();
        }
    }
}