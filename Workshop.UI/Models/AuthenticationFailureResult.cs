using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Workshop.UI.Models
{
    public class AuthenticationFailureResult
    {
        string ReasonePhares;
        public HttpRequestMessage Request { get; set; }
    }
}