using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Request;
using Workshop.Entities.ApiModels.PaymentVoucher.Request;

namespace Workshop.Api.Mapping.Request
{
    public class PaymentVoucherRequest : IPaymentVoucherRequest
    {
        private readonly IPaymentVoucherMapperConfiguration _paymentVoucherMapperConfiguration;
        public PaymentVoucherRequest(IPaymentVoucherMapperConfiguration paymentVoucherMapperConfiguration)
        {
            this._paymentVoucherMapperConfiguration = paymentVoucherMapperConfiguration;
        }
        public W_T_PaymentVoucher MapFromPaymentReqToDb(PaymentVoucherReq paymentVoucherReq)
        {
            return _paymentVoucherMapperConfiguration.GetMapper().Map<W_T_PaymentVoucher>(paymentVoucherReq);
        }
    }
}