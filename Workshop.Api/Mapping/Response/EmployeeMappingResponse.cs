using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.Entities.ApiModels.Employee;
using Workshop.Entities.ApiModels.Employee.Response;
using Workshop.Entities.DTO.Employee;

namespace Workshop.Api.Mapping.Response
{
    public class EmployeeMappingResponse : IEmployeeMappingResponse
    {
        private readonly IEmployeeMapperConfiguration _employeeMapperConfiguration;
        public EmployeeMappingResponse(IEmployeeMapperConfiguration employeeMapperConfiguration)
        {
            this._employeeMapperConfiguration = employeeMapperConfiguration;
        }
        public EmployeesResponse MapEmployeeDBModelToEmployeeDTO(IEnumerable<W_D_Employee> employees)
        {
            return _employeeMapperConfiguration.GetMapper().Map<EmployeesResponse>(employees);
        }

        public EmployeeResponse MapEmployeeDBModelToEmployeeDTO(W_D_Employee employee)
        {
            return _employeeMapperConfiguration.GetMapper().Map<EmployeeResponse>(employee);
        }
    }
}