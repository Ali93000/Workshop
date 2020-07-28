using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
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
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            // Get Data From DB
            var customers = _unitOfWork.CustomerRepository.GetAll();
            // Map Data To DTO
            var customerDTO = _customerMappingResponse.MapCustomerDTOFromDBCustomerModel(customers);
            return customerDTO;
        }

        public CustomerDTO GetCustomerById(int id)
        {
            // Get Data From Database
            var customers = _unitOfWork.CustomerRepository.GetById(id);
            // Map Result
            var customerDTO = _customerMappingResponse.MapCustomerDTOFromDBCustomerModel(customers);
            return customerDTO;
        }
    }
}
