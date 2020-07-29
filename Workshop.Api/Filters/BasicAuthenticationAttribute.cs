using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Workshop.Api.Filters
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                string token = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(token));
                string[] usernamePassworArray = decodedToken.Split(':');
                string username = usernamePassworArray[0];
                string password = usernamePassworArray[1];

                if (true)
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}