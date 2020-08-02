using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Workshop.UI.Models
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