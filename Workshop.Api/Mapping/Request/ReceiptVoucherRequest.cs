using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Request;
using Workshop.Entities.ApiModels.CashReceipt.Request;

namespace Workshop.Api.Mapping.Request
{
    public class ReceiptVoucherRequest : IReceiptVoucherMappingRequest
    {
        private readonly IReceiptVoucherMapperConfiguration _cashReceiptMapperConfiguration;
        public ReceiptVoucherRequest(IReceiptVoucherMapperConfiguration cashReceiptMapperConfiguration )
        {
            this._cashReceiptMapperConfiguration = cashReceiptMapperConfiguration;
        }
        public W_T_ReceiptVoucher mapFromCachReceiptReqToDB(ReceiptVoucherReq cachReceiptReq)
        {
            return _cashReceiptMapperConfiguration.GetMapper().Map<W_T_ReceiptVoucher>(cachReceiptReq);
        }
    }
}