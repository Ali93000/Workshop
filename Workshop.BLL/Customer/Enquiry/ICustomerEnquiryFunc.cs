using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Customer.Response;
using Workshop.Entities.DTO;

namespace Workshop.BLL.Customer.Enquiry
{
    public interface ICustomerEnquiryFunc
    {
        CustomersResponse GetAllCustomers();
        CustomerResponse GetCustomerById(int id);
    }
}
