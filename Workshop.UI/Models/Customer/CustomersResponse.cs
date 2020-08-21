using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.DTO;

namespace Workshop.UI.Models.Customer
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