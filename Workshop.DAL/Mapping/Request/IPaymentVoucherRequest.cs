using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.PaymentVoucher.Request;

namespace Workshop.DAL.Mapping.Request
{
 public   interface IPaymentVoucherRequest
    {
        W_T_PaymentVoucher MapFromPaymentReqToDb(PaymentVoucherReq paymentVoucherReq);
    }
}
