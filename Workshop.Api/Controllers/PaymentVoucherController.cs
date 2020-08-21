using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Helpers;
using Workshop.Api.JWTImplementation;
using Workshop.Api.Validation.Configuration;
using Workshop.BLL.PaymentVoucher.Enquiry;
using Workshop.BLL.PaymentVoucher.Operational;
using Workshop.Entities.ApiModels.PaymentVoucher.Request;
using Workshop.Entities.DTO.User;

namespace Workshop.Api.Controllers
{
    public class PaymentVoucherController : ApiController
    {
        private readonly IPaymentVoucherEnquiryFunc _paymentVoucherEnquiryFunc;
        private readonly IModelStateValidator _modelStateValidator;
        private readonly IPaymentVoucherOperationalFunc _paymentVoucherOperationalFunc;
        public PaymentVoucherController(IPaymentVoucherEnquiryFunc paymentVoucherEnquiryFunc, IModelStateValidator modelStateValidator, IPaymentVoucherOperationalFunc paymentVoucherOperationalFunc)
        {
            this._paymentVoucherEnquiryFunc = paymentVoucherEnquiryFunc;
            this._modelStateValidator = modelStateValidator;
            this._paymentVoucherOperationalFunc = paymentVoucherOperationalFunc;
        }
        // Get List
        [HttpGet, Route("api/v1/paymentvoucher")]
        public IHttpActionResult GetAllPaymentVoucher()
        {
            // Run BLL//
            var paymentVoucher = _paymentVoucherEnquiryFunc.GetAllPaymentVoucher();
            return new WorkHttpActionResult(paymentVoucher, HttpStatusCode.OK);
        }
        // Get By Id
        [HttpGet, Route("api/v1/paymentvoucher/{id}")]
        public IHttpActionResult GetPaymentVoucherByID(int id)
        {
            /// validat Modle
            var isValid = _modelStateValidator.ValidateModel(id);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            ////// Run Bll /////////
            var paymentVoucher = _paymentVoucherEnquiryFunc.GetPaymentVoucherByID(id);
            return new WorkHttpActionResult(paymentVoucher, HttpStatusCode.OK);
        }
        //// Add New Payment Voucher To Db ///
        [HttpPost, Route("api/v1/paymentvoucher")]
        public IHttpActionResult CreatePaymentVoucher(PaymentVoucherReq paymentVoucherReq)
        {
            /// model Valid ///
            var isValid = _modelStateValidator.ValidateModel(paymentVoucherReq);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }

            /// Read User Info From Request (JWT Information)
            var userInfo = TokenManager.ReadToken(Request.Headers.Authorization.Parameter);
            /// Run Bll ///
            int paymentReq = _paymentVoucherOperationalFunc.CreatPaymentVoucher(paymentVoucherReq, userInfo);
            return new WorkHttpActionResult("Payment Is Id  " + paymentReq, HttpStatusCode.Created);
        }

        //// Edite  Payment Voucher To Db ///
        [HttpPut, Route("api/v1/paymentvoucher")]
        public IHttpActionResult UpdatePaymentVoucher(PaymentVoucherReq paymentVoucherReq)
        {

            /// model Valid ///
            var isValid = _modelStateValidator.ValidateModel(paymentVoucherReq);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            /// Read User Info From Request (JWT Information)
            var userInfo = TokenManager.ReadToken(Request.Headers.Authorization.Parameter);
            /// Run Bll ///
            _paymentVoucherOperationalFunc.UpdatePaymentVoucher(paymentVoucherReq,userInfo);
            return new WorkHttpActionResult("Payment Updated Successfully ", HttpStatusCode.OK);
        }
        //// Delete  Payment Voucher To Db ///
        [HttpDelete, Route("api/v1/paymentvoucher/{id}")]
        public IHttpActionResult DeletePaymentVoucher(int id)
        {
            /// model Valid ///
            var isValid = _modelStateValidator.ValidateModel(id);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            /// Read User Info From Request (JWT Information)
            var userInfo = TokenManager.ReadToken(Request.Headers.Authorization.Parameter);
            /// Run Bll ///
            _paymentVoucherOperationalFunc.DeletePaymentVoucher(id);
            return new WorkHttpActionResult("Payment Delete Successfully ", HttpStatusCode.OK);
        }

    }

}
