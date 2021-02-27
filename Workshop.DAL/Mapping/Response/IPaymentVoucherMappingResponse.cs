using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.PaymentVoucher.Response;

namespace Workshop.DAL.Mapping.Response
{
  public  interface IPaymentVoucherMappingResponse
    {
        PaymentVoucherResponse MapFromDtoTOMapDb(IEnumerable<W_T_PaymentVoucher> dbPaymentVoucher);
        PaymentVoucherIDResponse mapFromDtoIDToMabDb(W_T_PaymentVoucher dbPaymentVoucher);
    }
}
