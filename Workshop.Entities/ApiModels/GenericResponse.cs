using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.ApiModels
{
    public class GenericResponse
    {
        public GenericResponse()
        {
            ResponseMessages = new List<string>();
        }
        public bool IsSuccessful { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
        public List<string> ResponseMessages { get; set; }
    }
}
