using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.Entities.ApiModels.Employee;
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
        public IEnumerable<EmployeeDTO> MapEmployeeDBModelToEmployeeDTO(IEnumerable<W_D_Employee> employees)
        {
            return _employeeMapperConfiguration.GetMapper().Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public EmployeeDTO MapEmployeeDBModelToEmployeeDTO(W_D_Employee employee)
        {
            return _employeeMapperConfiguration.GetMapper().Map<EmployeeDTO>(employee);
        }
    }
}