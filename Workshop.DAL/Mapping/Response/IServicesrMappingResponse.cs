using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Services.Response;

namespace Workshop.DAL.Mapping.Response
{
 public  interface IServicesrMappingResponse
    {
        ServicesResponse mapFromDbToServicesDTO(IEnumerable<W_D_Services> services);
        ServicesIDResponse mapFromDbToServicesDTO(W_D_Services services);
    }
}
