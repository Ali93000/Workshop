using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Customer;

namespace Workshop.DAL.Mapping.Request
{
    public interface ICustomerReqMappingRequest
    {
        W_D_Customer MapDBCustomerModelToCustomerReq(CustomerReq customerReq);
    }
}
