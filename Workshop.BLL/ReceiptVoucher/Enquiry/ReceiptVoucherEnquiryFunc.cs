using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.Implementation;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.CashReceipt.Response;
using Workshop.Entities.ApiModels.Services.Response;

namespace Workshop.BLL.CachReceipt.Enquiry
{
    public class ReceiptVoucherEnquiryFunc : IReceiptVoucherEnquiryFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReceiptVoucherMappingResponse _cashReceiptMappingResponse;
        public ReceiptVoucherEnquiryFunc(IUnitOfWork unitOfWork, IReceiptVoucherMappingResponse cashReceiptMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._cashReceiptMappingResponse = cashReceiptMappingResponse;
        }
        public ReceiptVoucherResponse GetAllCashReceipt()
        {
            // Get List OF CashReceipt From DB
            var CashReceipt = _unitOfWork.ReceiptVoucherReopsitry.GetAll();
            if (CashReceipt == null)
            {
                return new ReceiptVoucherResponse { IsSuccessful = false, ResponseCode = System.Net.HttpStatusCode.NotFound, cachReceiptList = null, ResponseMessages = new List<string> { "No Data Found" } };
            }
            //map Result To DTO
            var cashResponse = _cashReceiptMappingResponse.mapFromDbToCashReceiptDTOResponse(CashReceipt);
            cashResponse.IsSuccessful = true;
            cashResponse.ResponseCode = System.Net.HttpStatusCode.OK;
            return cashResponse;

        }

        public ReceiptVoucherIDResponse GetCachById(int id)
        {
            // Get By Id OF CashReceipt From DB
            var cachReceiptId = _unitOfWork.ReceiptVoucherReopsitry.GetById(id);
            if (cachReceiptId == null)
            {
                return new ReceiptVoucherIDResponse { IsSuccessful = false, ResponseCode = System.Net.HttpStatusCode.NotFound, CachReceiptID = null, ResponseMessages = new List<string> { "Nout Found" } };
            }
            // Map Result To DTO
            var cachIdRespons = _cashReceiptMappingResponse.maoFromDbToCachreceiptDTO(cachReceiptId);
            cachIdRespons.IsSuccessful = true;
            cachIdRespons.ResponseCode = System.Net.HttpStatusCode.OK;
            return cachIdRespons;
        }

              
    }
}
