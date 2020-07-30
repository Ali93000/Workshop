using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Employee;
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
            });
            return config.CreateMapper();
        }
    }
}