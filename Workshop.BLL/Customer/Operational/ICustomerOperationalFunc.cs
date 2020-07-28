using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;

namespace Workshop.BLL.Customer.Operational
{
    public interface ICustomerOperationalFunc
    {
        int CreateCustomer(W_D_Customer customerDB);
        void UpdateCustomer(W_D_Customer customerDB);
        void DeleteCustomer(int Id);
    }
}
