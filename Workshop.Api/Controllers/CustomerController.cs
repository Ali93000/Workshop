using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Helpers;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.Api.Validation.Configuration;
using Workshop.BLL.Customer.Enquiry;
using Workshop.BLL.Customer.Operational;
using Workshop.DAL.Mapping.Request;
using Workshop.Entities.ApiModels.Customer;
using Workshop.Entities.DTO;

namespace Workshop.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerEnquiryFunc _customerEnquiryFunc;
        private readonly IModelStateValidator _modelStateValidator;
        private readonly ICustomerReqMappingRequest _customerReqMappingRequest;
        private readonly ICustomerOperationalFunc _customerOperationalFunc; 
        public CustomerController(ICustomerEnquiryFunc customerEnquiryFunc, ICustomerMapperConfiguration customerMapperConfiguration, IModelStateValidator modelStateValidator, ICustomerReqMappingRequest customerReqMappingRequest, ICustomerOperationalFunc customerOperationalFunc)
        {
            this._customerEnquiryFunc = customerEnquiryFunc;
            this._modelStateValidator = modelStateValidator;
            this._customerReqMappingRequest = customerReqMappingRequest;
            this._customerOperationalFunc = customerOperationalFunc;
        }


        [HttpGet, Route("api/v1/customer")]
        public IHttpActionResult GetAllCustomer()
        {
            // Run Business
            var customers = _customerEnquiryFunc.GetAllCustomers();
            return new WorkHttpActionResult(customers, HttpStatusCode.OK);
        }

        [HttpGet, Route("api/v1/customer/{id}")]
        public IHttpActionResult GetCustomerById(int id)
        {
            // Validate Model
            var Isvalid = _modelStateValidator.ValidateModel(id);
            if (Isvalid != null)
            {
                return new WorkHttpActionResult(Isvalid, Isvalid.ResponseCode);
            }
            // Run Business
            var currentCustomer = _customerEnquiryFunc.GetCustomerById(id);
            return new WorkHttpActionResult(currentCustomer, HttpStatusCode.OK);
        }

        [HttpPost, Route("api/v1/customer")]
        public IHttpActionResult CreateCustomer(CustomerReq customerReq)
        {
            // Validate Model
            var IsValid = _modelStateValidator.ValidateModel(customerReq);
            if (IsValid != null)
            {
                return new WorkHttpActionResult(IsValid.ResponseMessages, (HttpStatusCode)422);
            }
            // Map Model
            var customerDb = _customerReqMappingRequest.MapDBCustomerModelToCustomerReq(customerReq);
            // Run Businss
            int customerId = _customerOperationalFunc.CreateCustomer(customerDb);
            return new WorkHttpActionResult($"Customer Creadted With Id = {customerId}", HttpStatusCode.Created);
        }

        [HttpPut, Route("api/v1/customer")]
        public IHttpActionResult UpdateCustomer(CustomerReq customerReq)
        {
            // Validate Model
            var IsValid = _modelStateValidator.ValidateModel(customerReq);
            if (IsValid != null)
            {
                return new WorkHttpActionResult(IsValid, (HttpStatusCode)422);
            }
            // Map Model
            var customerDB = _customerReqMappingRequest.MapDBCustomerModelToCustomerReq(customerReq);
            // Run Business
            _customerOperationalFunc.UpdateCustomer(customerDB);
            return new WorkHttpActionResult("Customer Updated Successfuly", HttpStatusCode.OK);
        }

        [HttpDelete, Route("api/v1/customer/{id}")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            // Validate Model
            var IsValid = _modelStateValidator.ValidateModel(id);
            if (IsValid != null)
            {
                return new WorkHttpActionResult(IsValid, IsValid.ResponseCode);
            }
            // Run Businss
            _customerOperationalFunc.DeleteCustomer(id);
            return new WorkHttpActionResult("Customer Deleted Successfuly", HttpStatusCode.OK);
        }
    }
}
