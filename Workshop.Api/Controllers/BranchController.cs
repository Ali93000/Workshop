using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Helpers;
using Workshop.BLL.Branch.Enquiry;

namespace Workshop.Api.Controllers
{
    public class BranchController : ApiController
    {
        private readonly IBranchEnquiryFunc _branchEnquiryFunc;
        public BranchController(IBranchEnquiryFunc branchEnquiryFunc)
        {
            this._branchEnquiryFunc = branchEnquiryFunc;
        }
        [HttpGet, Route("api/v1/branch")]
        public IHttpActionResult GetAllBranches()
        {
            // Run BLL
            var brances = _branchEnquiryFunc.GetAllBranches();
            return new WorkHttpActionResult(brances, HttpStatusCode.OK);
        }
    }
}
