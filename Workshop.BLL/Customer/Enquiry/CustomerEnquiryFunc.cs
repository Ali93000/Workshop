using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Repository.UnitOfWork;

namespace Workshop.BLL.Customer.Enquiry
{
    public class CustomerEnquiryFunc : ICustomerEnquiryFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerEnquiryFunc(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IEnumerable<W_D_Customer> GetAllCustomers()
        {
            return _unitOfWork.CustomerRepository.GetAll();
        }
    }
}
