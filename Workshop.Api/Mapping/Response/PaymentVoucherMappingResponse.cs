using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.Entities.ApiModels.PaymentVoucher.Response;
using Workshop.Entities.DTO.PaymentVoucher;

namespace Workshop.Api.Mapping.Response
{
    public class PaymentVoucherMappingResponse : IPaymentVoucherMappingResponse
    {
        private readonly IPaymentVoucherMapperConfiguration _paymentVoucherMapperConfiguration;
        public PaymentVoucherMappingResponse(IPaymentVoucherMapperConfiguration paymentVoucherMapperConfiguration)
        {
            this._paymentVoucherMapperConfiguration = paymentVoucherMapperConfiguration;
        }

        public PaymentVoucherIDResponse mapFromDtoIDToMabDb(W_T_PaymentVoucher dbPaymentVoucher)
        {
            return _paymentVoucherMapperConfiguration.GetMapper().Map<PaymentVoucherIDResponse> (dbPaymentVoucher);
        }

        public PaymentVoucherResponse MapFromDtoTOMapDb(IEnumerable<W_T_PaymentVoucher> dbPaymentVoucher)
        {
            return _paymentVoucherMapperConfiguration.GetMapper().Map<PaymentVoucherResponse>(dbPaymentVoucher);
        }
    }
}