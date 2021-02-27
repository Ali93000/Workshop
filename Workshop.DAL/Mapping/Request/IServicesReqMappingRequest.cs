using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Services.Request;

namespace Workshop.DAL.Mapping.Request
{
   public interface IServicesReqMappingRequest
    {
        W_D_Services mapFromSevicesReqToMapDB(ServicesReq servicesReq);
    }
}
