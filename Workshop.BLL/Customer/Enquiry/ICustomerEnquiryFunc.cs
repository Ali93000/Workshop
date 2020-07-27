using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;

namespace Workshop.BLL.Customer.Enquiry
{
    public interface ICustomerEnquiryFunc
    {
        IEnumerable<W_D_Customer> GetAllCustomers();
    }
}
