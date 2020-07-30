using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using Workshop.Api.JWTImplementation;

namespace Workshop.Api.Filters
{
    public class JWTAuthentication : AuthorizeAttribute, IAuthenticationFilter
    {
        private readonly ITokenManager _tokenManager;
        public JWTAuthentication(ITokenManager tokenManager)
        {
            this._tokenManager = tokenManager;
        }
        public bool AllowMultiple
        {
            get { return false; }
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            string authParameter = string.Empty;
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            string[] TokenAndUser = null;

            if (authorization == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Authorization Header", request);
                return;
            }

            if (authorization.Scheme != "Bearer")
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid Authorization Schema", request);
                return;
            }

            TokenAndUser = authorization.Parameter.Split(':');
            string Token = TokenAndUser[0];
            //string username = TokenAndUser[1];

            if (string.IsNullOrEmpty(Token))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Token", request);
                return;
            }

            string validUserName = _tokenManager.ValidateToken(Token);
            //if (username != validUserName)
            //{
            //    context.ErrorResult = new AuthenticationFailureResult("Invalid Token For User", request);
            //    return;
            //}

            context.Principal = _tokenManager.GetPrincipal(Token);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);
            if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic", "realm=localhost"));
            }

            context.Result = new ResponseMessageResult(result);
        }


        public class AuthenticationFailureResult : IHttpActionResult
        {
            string ReasonePhares;
            public HttpRequestMessage Request { get; set; }


            public AuthenticationFailureResult(string reasonePhares, HttpRequestMessage request)
            {
                ReasonePhares = reasonePhares;
                Request = request;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(Execute());
            }

            public HttpResponseMessage Execute()
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                responseMessage.RequestMessage = Request;
                responseMessage.ReasonPhrase = ReasonePhares;
                return responseMessage;
            }
        }
    }
}