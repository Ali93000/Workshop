using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Filters;
using Workshop.Api.Helpers;
using Workshop.Api.JWTImplementation;
using Workshop.BLL.Branch.Enquiry;

namespace Workshop.Api.Controllers
{
    //[JWTAuthentication]
    public class BranchController : ApiController
    {
        private readonly IBranchEnquiryFunc _branchEnquiryFunc;
        public BranchController(IBranchEnquiryFunc branchEnquiryFunc)
        {
            this._branchEnquiryFunc = branchEnquiryFunc;
        }
        [JWTAuthentication]
        [HttpGet, Route("api/v1/branch")]
        public IHttpActionResult GetAllBranches()
        {
            // Read Claims
            string token = Request.Headers.Authorization.Parameter;
            Entities.DTO.User.UserDTO claims = TokenManager.ReadToken(token);
            // Run BLL
            var brances = _branchEnquiryFunc.GetAllBranches();
            return new WorkHttpActionResult(brances, HttpStatusCode.OK);
        }
        [HttpGet, Route("api/v1/branchs")]
        public IHttpActionResult GetAllBranchesForCompany(int? compId)
        {
            // Run BLL
            var brances = _branchEnquiryFunc.GetAllBranches(compId);
            return new WorkHttpActionResult(brances, HttpStatusCode.OK);
        }
    }
}
