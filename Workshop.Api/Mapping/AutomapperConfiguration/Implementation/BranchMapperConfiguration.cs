using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Branch.Response;
using Workshop.Entities.DTO.Branch;

namespace Workshop.Api.Mapping.AutomapperConfiguration.Implementation
{
    public class BranchMapperConfiguration : IBranchMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<G_Branches, BranchDTO>()
                .ForMember(des => des.CompName, map =>
                map.MapFrom(src => src.G_Companies.NameEn));

                cfg.CreateMap<G_Branches, BranchResponse>()
                .ForMember(des => des.Branch, map =>
                 map.MapFrom(src => src));

                cfg.CreateMap<IEnumerable<G_Branches>, BranchesResponse>()
                .ForMember(des => des.BranchesList, map =>
                 map.MapFrom(src => src));
            });
            return config.CreateMapper();
        }
    }
}