using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.BLL.Customer.Enquiry;
using Workshop.Entities.DTO;

namespace Workshop.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerEnquiryFunc _customerEnquiryFunc;
        private readonly ICustomerMapperConfiguration _customerMapperConfiguration;
        public CustomerController(ICustomerEnquiryFunc customerEnquiryFunc, ICustomerMapperConfiguration customerMapperConfiguration)
        {
            this._customerEnquiryFunc = customerEnquiryFunc;
            this._customerMapperConfiguration = customerMapperConfiguration;
        }


        [HttpGet, Route("api/v1/customer")]
        public IHttpActionResult GetAllCustomer()
        {
            // Run Business
            var customers = _customerEnquiryFunc.GetAllCustomers();
            // Map Result to DTO
            var customerDTO = _customerMapperConfiguration.GetMapper().Map<List<CustomerDTO>>(customers);
            return Ok(customerDTO);
        }
    }
}
