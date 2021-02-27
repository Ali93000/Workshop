using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.PaymentVoucher.Response;

namespace Workshop.BLL.PaymentVoucher.Enquiry
{
    public class PaymentVoucherEnquiryFunc : IPaymentVoucherEnquiryFunc
    {
        private readonly IPaymentVoucherMappingResponse _paymentVoucherMappingResponse;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentVoucherEnquiryFunc(IPaymentVoucherMappingResponse paymentVoucherMappingResponse,IUnitOfWork unitOfWork)
        {
            this._paymentVoucherMappingResponse = paymentVoucherMappingResponse;
            this._unitOfWork = unitOfWork;
        }
        public PaymentVoucherResponse GetAllPaymentVoucher()
        {
            // get List Payment Voucher From Db//
            var PaymentVoucher = _unitOfWork.paymentVoucherReopsitry.GetAll();
            if (PaymentVoucher == null)
            {
                return new PaymentVoucherResponse { IsSuccessful = false, ResponseCode = System.Net.HttpStatusCode.NotFound, PaymentVoucherList = null, ResponseMessages = new List<string> { "Nout Found" } };
            }
            // Map Result DTo
            var pvResponse = _paymentVoucherMappingResponse.MapFromDtoTOMapDb(PaymentVoucher);
            pvResponse.IsSuccessful = true;
            pvResponse.ResponseCode = System.Net.HttpStatusCode.OK;
            return pvResponse;

        }

        public PaymentVoucherIDResponse GetPaymentVoucherByID(int id)
        {
            //Get ID Payment Voucher From DB
            var paymentVoucherId = _unitOfWork.paymentVoucherReopsitry.GetById(id);
            if (paymentVoucherId==null)
            {
                return new PaymentVoucherIDResponse { IsSuccessful = false, ResponseCode = System.Net.HttpStatusCode.NotFound, PaymentVoucherID = null, ResponseMessages = new List<string> { "Nout Found" } };
                            }
            //// map result DTO
            ///
            var pvIdResponse = _paymentVoucherMappingResponse.mapFromDtoIDToMabDb(paymentVoucherId);
            pvIdResponse.IsSuccessful = true;
            pvIdResponse.ResponseCode = System.Net.HttpStatusCode.OK;
            return pvIdResponse;
        }

      
    }
}
