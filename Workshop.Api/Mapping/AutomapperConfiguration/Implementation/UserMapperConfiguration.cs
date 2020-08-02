using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.User.Request;
using Workshop.Entities.ApiModels.User.Response;
using Workshop.Entities.DTO.User;

namespace Workshop.Api.Mapping.AutomapperConfiguration.Implementation
{
    public class UserMapperConfiguration : IUserMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserLoginReq, G_USERS>();

                cfg.CreateMap<G_USERS, UserDTO>()
                .ForMember(des => des.RoleName, map => 
                map.MapFrom(src => src.UserRole.RoleNameEn))
                .ForMember(des=> des.CompName, map =>
                map.MapFrom(src =>src.G_Companies.NameEn));

                cfg.CreateMap<G_USERS, UserLoginInfoResponse>()
                .ForMember(des => des.UserLoginInfo, map =>
                 map.MapFrom(src => src));
                //.ForMember(des => des.UserLoginInfo.RoleName, map =>
                //map.MapFrom(src => src.UserRole.RoleNameEn));
            });
            return config.CreateMapper();
        }
    }
}