using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO;

namespace Workshop.Entities.ApiModels.Customer.Response
{
    public class CustomersResponse : GenericResponse
    {
        public CustomersResponse()
        {
            CustomersList = new List<CustomerDTO>();
        }
        public List<CustomerDTO> CustomersList { get; set; }
    }
}
