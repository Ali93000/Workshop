using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Customer.Response;
using Workshop.Entities.DTO;

namespace Workshop.DAL.Mapping.Response
{
    public interface ICustomerMappingResponse 
    {
        CustomersResponse MapCustomerDTOFromDBCustomerModel(IEnumerable<W_D_Customer> DBCustomer);
        CustomerResponse MapCustomerDTOFromDBCustomerModel(W_D_Customer DBCustomer);
    }
}
