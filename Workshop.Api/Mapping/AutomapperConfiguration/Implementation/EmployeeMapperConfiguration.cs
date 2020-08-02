using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Employee;
using Workshop.Entities.ApiModels.Employee.Response;
using Workshop.Entities.DTO.Employee;

namespace Workshop.Api.Mapping.AutomapperConfiguration.Implementation
{
    public class EmployeeMapperConfiguration : IEmployeeMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<W_D_Employee, EmployeeDTO>();

                cfg.CreateMap<EmployeeReq, W_D_Employee>();

                cfg.CreateMap<IEnumerable<W_D_Employee>, EmployeesResponse>()
                .ForMember(des =>des.EmployeesList, map =>
                map.MapFrom(src =>src));
                
                cfg.CreateMap<W_D_Employee, EmployeeResponse>()
                .ForMember(des =>des.Employee, map =>
                map.MapFrom(src =>src));
            });
            return config.CreateMapper();
        }
    }
}