using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.ApiModels.Services.Request;

namespace Workshop.BLL.Services.Operational
{
  public  interface IServicesOperationalFunc
    {
        int CreateServices(ServicesReq servicesReq);
        void UpdateServices(ServicesReq servicesReq);
        void DeteteServices(int id);
    }
}
