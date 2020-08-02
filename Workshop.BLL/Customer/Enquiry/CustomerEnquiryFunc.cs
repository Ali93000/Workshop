using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Customer.Response;
using Workshop.Entities.DTO;

namespace Workshop.BLL.Customer.Enquiry
{
    public class CustomerEnquiryFunc : ICustomerEnquiryFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerMappingResponse _customerMappingResponse;
        public CustomerEnquiryFunc(IUnitOfWork unitOfWork, ICustomerMappingResponse customerMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._customerMappingResponse = customerMappingResponse;
        }
        public CustomersResponse GetAllCustomers()
        {
            // Get Data From DB
            var customers = _unitOfWork.CustomerRepository.GetAll();
            if (customers == null)
            {
                return new CustomersResponse { IsSuccessful = false, CustomersList = null, ResponseCode = System.Net.HttpStatusCode.NotFound, ResponseMessages = new List<string> { "No Data Found" } };
            }
            // Map Data To DTO
            var customerDTO = _customerMappingResponse.MapCustomerDTOFromDBCustomerModel(customers);
            customerDTO.IsSuccessful = true;
            customerDTO.ResponseCode = System.Net.HttpStatusCode.OK;
            return customerDTO;
        }

        public CustomerResponse GetCustomerById(int id)
        {
            // Get Data From Database
            var customers = _unitOfWork.CustomerRepository.GetById(id);
            if (customers == null)
            {
                return new CustomerResponse { IsSuccessful = false, Customer = null, ResponseCode = System.Net.HttpStatusCode.NotFound, ResponseMessages = new List<string> { "No Data Found " } };
            }
            // Map Result
            var customerDTO = _customerMappingResponse.MapCustomerDTOFromDBCustomerModel(customers);
            customerDTO.IsSuccessful = true;
            customerDTO.ResponseCode = System.Net.HttpStatusCode.OK;
            return customerDTO;
        }
    }
}
