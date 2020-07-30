using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Helpers;
using Workshop.Api.Validation.Configuration;
using Workshop.BLL.Employee.Enquiry;
using Workshop.BLL.Employee.Operational;
using Workshop.DAL.Mapping.Response;
using Workshop.Entities.ApiModels.Employee;

namespace Workshop.Api.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeMappingResponse _employeeMappingResponse;
        private readonly IModelStateValidator _modelStateValidator;
        private readonly IEmployeeEnquiryFunc _employeeEnquiryFunc;
        private readonly IEmployeeOperationaFunc _employeeOperationaFunc;
        public EmployeeController(IEmployeeEnquiryFunc employeeEnquiryFunc, IEmployeeMappingResponse employeeMappingResponse, IModelStateValidator modelStateValidator, IEmployeeOperationaFunc employeeOperationaFunc)
        {
            this._employeeEnquiryFunc = employeeEnquiryFunc;
            this._employeeMappingResponse = employeeMappingResponse;
            this._modelStateValidator = modelStateValidator;
            this._employeeOperationaFunc = employeeOperationaFunc;
        }

        [HttpGet, Route("api/v1/employee")]
        public IHttpActionResult GetAllEmployee()
        {
            // Run Businss
            var employees = _employeeEnquiryFunc.GetAllEmployee();
            return new WorkHttpActionResult(employees, HttpStatusCode.OK);
        }

        [HttpGet, Route("api/v1/employee/{id}")]
        public IHttpActionResult GetEmployeeById(int id)
        {
            // Validate Model
            var IsValid = _modelStateValidator.ValidateModel(id);
            if (IsValid != null)
            {
                return new WorkHttpActionResult(IsValid, IsValid.ResponseCode);
            }
            // Run Businss
            var employee = _employeeEnquiryFunc.GetEmployeeById(id);
            return new WorkHttpActionResult(employee, HttpStatusCode.OK);
        }

        [HttpPost, Route("api/v1/employee")]
        public IHttpActionResult CreateEmployee(EmployeeReq employeeReq)
        {
            var IsValid = _modelStateValidator.ValidateModel(employeeReq);
            if (IsValid != null)
            {
                return new WorkHttpActionResult(IsValid, IsValid.ResponseCode);
            }
            // Run Businss
            var empId = _employeeOperationaFunc.CreateEmployee(employeeReq);
            return new WorkHttpActionResult($"Employee Created With Id {empId}", HttpStatusCode.Created);
        }

        [HttpPut, Route("api/v1/employee")]
        public IHttpActionResult UpdateEmployee(EmployeeReq employeeReq)
        {
            // Validate Model 
            var IsValid = _modelStateValidator.ValidateModel(employeeReq);
            if (IsValid != null)
            {
                return new WorkHttpActionResult(IsValid, IsValid.ResponseCode);
            }
            // Run Business
            _employeeOperationaFunc.UpdateEmployee(employeeReq);
            return new WorkHttpActionResult("Employee Updated Successfuly", HttpStatusCode.OK);
        }

        [HttpDelete, Route("api/v1/employee/{id}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            // Validate Model 
            var IsValid = _modelStateValidator.ValidateModel(id);
            if (IsValid != null)
            {
                return new WorkHttpActionResult(IsValid, IsValid.ResponseCode);
            }
            // Run Businss
            _employeeOperationaFunc.DeleteEmployee(id);
            return new WorkHttpActionResult("Employee Removed Successfully", HttpStatusCode.OK);
        }
    }
}
