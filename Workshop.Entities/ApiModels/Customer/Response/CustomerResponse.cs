using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO;

namespace Workshop.Entities.ApiModels.Customer.Response
{
    public class CustomerResponse : GenericResponse
    {
        public CustomerResponse()
        {
            Customer = new CustomerDTO();
        }
        public CustomerDTO Customer { get; set; }
    }
}
