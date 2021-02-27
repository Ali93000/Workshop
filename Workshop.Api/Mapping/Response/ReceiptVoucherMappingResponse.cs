using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.Entities.ApiModels.CashReceipt.Response;

namespace Workshop.Api.Mapping.Response
{
    public class ReceiptVoucerMappingResponse : IReceiptVoucherMappingResponse
    {
        private readonly IReceiptVoucherMapperConfiguration _cashReceiptMapperConfiguration;
        public ReceiptVoucerMappingResponse(IReceiptVoucherMapperConfiguration cashReceiptMapperConfiguration)
        {
            this._cashReceiptMapperConfiguration = cashReceiptMapperConfiguration;
        }
        //Get By ID
        public ReceiptVoucherIDResponse maoFromDbToCachreceiptDTO(W_T_ReceiptVoucher w_T_CachReceipt)
        {
            return _cashReceiptMapperConfiguration.GetMapper().Map<ReceiptVoucherIDResponse>(w_T_CachReceipt);
        }
        //Get List
        public ReceiptVoucherResponse mapFromDbToCashReceiptDTOResponse(IEnumerable<W_T_ReceiptVoucher> cachReceipts)
        {
            return _cashReceiptMapperConfiguration.GetMapper().Map<ReceiptVoucherResponse>(cachReceipts);
        }
    }
}