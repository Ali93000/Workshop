using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Helpers;
using Workshop.Api.JWTImplementation;
using Workshop.Api.Validation.Configuration;
using Workshop.BLL.User.Enquiry;
using Workshop.BLL.User.Operational;
using Workshop.Entities.ApiModels.User.Request;
using Workshop.Entities.ApiModels.User.Response;

namespace Workshop.Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IModelStateValidator  _modelStateValidator;
        private readonly IUserEnquiryFunc _userEnquiryFunc;
        private readonly ITokenManager _tokenManager;
        public UsersController(IModelStateValidator modelStateValidator, IUserEnquiryFunc userEnquiryFunc, ITokenManager tokenManager)
        {
            this._modelStateValidator = modelStateValidator;
            this._userEnquiryFunc = userEnquiryFunc;
            this._tokenManager = tokenManager;
        }

        [HttpPost, Route("api/v1/users/login")]
        public IHttpActionResult Login(UserLoginReq userLoginReq)
        {
            // Validate Model
            var isValid = _modelStateValidator.ValidateModel(userLoginReq);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            var userInfo = _userEnquiryFunc.UserLogin(userLoginReq);
            return new WorkHttpActionResult(userInfo, HttpStatusCode.OK);
        }

        [HttpPost, Route("api/v1/users/token")]
        public IHttpActionResult GenerateAccessToken(UserLoginInfoResponse userLoginInfo)
        {
            var userDTO = userLoginInfo.UserLoginInfo;
            var token = _tokenManager.GenerateToken(userDTO);
            return new WorkHttpActionResult(token, HttpStatusCode.OK);
        }
    }
}
