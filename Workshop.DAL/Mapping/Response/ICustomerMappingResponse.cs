using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.DTO;

namespace Workshop.DAL.Mapping.Response
{
    public interface ICustomerMappingResponse 
    {
        IEnumerable<CustomerDTO> MapCustomerDTOFromDBCustomerModel(IEnumerable<W_D_Customer> DBCustomer);
        CustomerDTO MapCustomerDTOFromDBCustomerModel(W_D_Customer DBCustomer);
    }
}
