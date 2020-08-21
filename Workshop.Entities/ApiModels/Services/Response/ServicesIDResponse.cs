using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.Services;

namespace Workshop.Entities.ApiModels.Services.Response
{
    
    public class ServicesIDResponse :GenericResponse
    {
        public ServicesDTO servicesId { get; set; }
        public ServicesIDResponse()
        {
            servicesId = new ServicesDTO();
        }    
       
    }
    
}
