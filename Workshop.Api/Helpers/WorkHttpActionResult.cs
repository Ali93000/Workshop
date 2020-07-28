using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Workshop.Api.Helpers
{
    public class WorkHttpActionResult : IHttpActionResult
    {
        private object _Content;
        private HttpStatusCode _StatusCode;
        public WorkHttpActionResult(object content, HttpStatusCode statusCode)
        {
            this._Content = content;
            this._StatusCode = statusCode;
        }    

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return new HttpResponseMessage(_StatusCode)
                {
                    Content = new ObjectContent(_Content.GetType(), _Content, new JsonMediaTypeFormatter())
                };
            });
        }
    }
}