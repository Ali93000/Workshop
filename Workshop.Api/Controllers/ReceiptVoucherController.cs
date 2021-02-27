using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Helpers;
using Workshop.Api.Validation.Configuration;
using Workshop.BLL.CachReceipt.Enquiry;
using Workshop.BLL.CachReceipt.Operational;
using Workshop.Entities.ApiModels.CashReceipt.Request;

namespace Workshop.Api.Controllers
{
    public class ReceiptVoucherController : ApiController
    {
        private readonly IReceiptVoucherEnquiryFunc _cashReceiptEnquiryFunc;
        private readonly IModelStateValidator _modelStateValidator;
        private readonly IReceiptVoucherOperationalFunc _cachReceiptOperationalFunc;
        public ReceiptVoucherController(IReceiptVoucherEnquiryFunc cashReceiptEnquiryFunc, IModelStateValidator modelStateValidator, IReceiptVoucherOperationalFunc cachReceiptOperationalFunc)
        {
            this._cashReceiptEnquiryFunc = cashReceiptEnquiryFunc;
            this._modelStateValidator = modelStateValidator;
            this._cachReceiptOperationalFunc = cachReceiptOperationalFunc;
        }
        // Get List From CachReceipt //
        [HttpGet, Route("api/v1/receiptvoucher")]
        public IHttpActionResult GetCachReceipt()
        {
            //Run Bll
            var cachReceipt = _cashReceiptEnquiryFunc.GetAllCashReceipt();
            return new WorkHttpActionResult(cachReceipt, HttpStatusCode.OK);
        }
        // Get Id From CachReceipt//
        [HttpGet, Route("api/v1/receiptvoucher/{id}")]
        public IHttpActionResult GetCachReceiptById(int id)
        {
            //// Validat Modle
            var isValid = _modelStateValidator.ValidateModel(id);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            //run Bll
            var CachReceiptId = _cashReceiptEnquiryFunc.GetCachById(id);
            return new WorkHttpActionResult(CachReceiptId, HttpStatusCode.OK);
        }
        //Create New CachReceipt//
        [HttpPost, Route("api/v1/receiptvoucher")]
        public IHttpActionResult CeateCahReceipt(ReceiptVoucherReq cachreceiptReq)
        {
            /// Validat Modle//
            var isValidat = _modelStateValidator.ValidateModel(cachreceiptReq);
            if (isValidat != null)
            {
                return new WorkHttpActionResult(isValidat, isValidat.ResponseCode);
            }
            //RUN BLL//
            int cachreceipt = _cachReceiptOperationalFunc.CreateCachReceipt(cachreceiptReq);
            return new WorkHttpActionResult($"Create whith Id {cachreceipt}", HttpStatusCode.Created);
        }
        // Edit CachReceipt //
        [HttpPut, Route("api/v1/receiptvoucher")]
        public IHttpActionResult UpdateCachReceipt(ReceiptVoucherReq cachReceiptReq)
        {
            // valid Modle//
            var isValid = _modelStateValidator.ValidateModel(cachReceiptReq);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // run Bll//
            _cachReceiptOperationalFunc.UpdateCachReceipt(cachReceiptReq);
            return new WorkHttpActionResult("CachRecipt IS Update", HttpStatusCode.OK);

        }
        //Delete CashRecept//
        [HttpDelete, Route("api/v1/receiptvoucher/{id}")]
        public IHttpActionResult DeleteCachRecept(int id)
        {
            // valid Modle
            var isvalid = _modelStateValidator.ValidateModel(id);
            if (isvalid != null)
            {
                return new WorkHttpActionResult(isvalid, isvalid.ResponseCode);
            }
            // Run Blll
            _cachReceiptOperationalFunc.DeleteCachReceipt(id);
            return new WorkHttpActionResult("CachDelte Is Delete", HttpStatusCode.OK);
        }
    }
}

