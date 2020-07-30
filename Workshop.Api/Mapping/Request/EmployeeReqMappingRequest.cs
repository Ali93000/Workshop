using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Request;
using Workshop.Entities.ApiModels.Employee;

namespace Workshop.Api.Mapping.Request
{
    public class EmployeeReqMappingRequest : IEmployeeReqMappingRequest
    {
        private readonly IEmployeeMapperConfiguration _employeeMapperConfiguration;
        public EmployeeReqMappingRequest(IEmployeeMapperConfiguration employeeMapperConfiguration)
        {
            this._employeeMapperConfiguration = employeeMapperConfiguration;
        }
        public W_D_Employee MapEmployeeReqToDBModel(EmployeeReq employeeReq)
        {
            return _employeeMapperConfiguration.GetMapper().Map<W_D_Employee>(employeeReq);
        }
    }
}