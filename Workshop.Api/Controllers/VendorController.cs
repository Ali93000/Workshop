using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Helpers;
using Workshop.Api.JWTImplementation;
using Workshop.Api.Validation.Configuration;
using Workshop.BLL.Vendor.Enquiry;
using Workshop.BLL.Vendor.Operational;
using Workshop.Entities.ApiModels.Vendor.Request;

namespace Workshop.Api.Controllers
{
    public class VendorController : ApiController
    {
        private readonly IVendorEnquiryFunc _vendorEnquiryFunc;
        private readonly IModelStateValidator _modelStateValidator;
        private readonly IVendorOperationalFunc _vendorOperationalFunc;
        public VendorController(IVendorEnquiryFunc vendorEnquiryFunc, IModelStateValidator modelStateValidator, IVendorOperationalFunc vendorOperationalFunc)
        {
            this._vendorEnquiryFunc = vendorEnquiryFunc;
            this._modelStateValidator = modelStateValidator;
            this._vendorOperationalFunc = vendorOperationalFunc;
        }
        // Validate Model
        // Run BLL >> Get Data From DB >> Map To Dto (Response)
        // Return Data
        [HttpGet, Route("api/v1/vendor")]
        public IHttpActionResult GetAllVendors()
        {
            // Run BLL
            var vendors = _vendorEnquiryFunc.GetAllVendor();
            return new WorkHttpActionResult(vendors, HttpStatusCode.OK);
        }

        [HttpGet, Route("api/v1/vendor/{id}")]
        public IHttpActionResult GetVendorById(int id)
        {
            // Validate Model
            var isValid = _modelStateValidator.ValidateModel(id);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            var vendor = _vendorEnquiryFunc.GetVendorById(id);
            return new WorkHttpActionResult(vendor, HttpStatusCode.OK);
        }

        [HttpPost, Route("api/v1/vendor")]
        public IHttpActionResult CreateVendor(VendorReq vendorReq)
        {
            // Validate Model
            var isValid = _modelStateValidator.ValidateModel(vendorReq);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            int vendorId = _vendorOperationalFunc.CreateVendor(vendorReq);
            return new WorkHttpActionResult("Vendor Created With Id  " + vendorId, HttpStatusCode.Created);
        }

        [HttpPut, Route("api/v1/vendor")]
        public IHttpActionResult UpdateVendor(VendorReq vendorReq)
        {
            string token = Request.Headers.Authorization.Parameter;
            var privilages = TokenManager.ReadToken(token);
            int? compCode = privilages.CompCode;
            int? braCode = privilages.BraCode;
            // Validate Model
            var isValid = _modelStateValidator.ValidateModel(vendorReq);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            _vendorOperationalFunc.UpdateVendor(vendorReq);
            return new WorkHttpActionResult("Vendor Updated Successfuly", HttpStatusCode.OK);
        }

        [HttpDelete, Route("api/v1/vendor")]
        public IHttpActionResult DeleteVendor(int id)
        {
            // Validate Model
            var isValid = _modelStateValidator.ValidateModel(id);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            _vendorOperationalFunc.DeleteVendor(id);
            return new WorkHttpActionResult("Vendor Deleted", HttpStatusCode.OK);
        }
    }
}
