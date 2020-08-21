using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.Services;

namespace Workshop.Entities.ApiModels.Services.Response
{
  public  class ServicesResponse :GenericResponse
    {
        public ServicesResponse()
        {
            servicesList = new List<ServicesDTO>();
        }
        public List<ServicesDTO> servicesList  { get; set; }
    }
}
