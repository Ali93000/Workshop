using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.ApiModels.Services.Response;

namespace Workshop.BLL.Services.Enquiry
{
   public interface IServicesEnquiryFunc
    {
        ServicesResponse GetAllServices();
        ServicesIDResponse GetServicesByID(int id);
    }
}
