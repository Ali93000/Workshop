using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.ApiModels.PaymentVoucher.Response;

namespace Workshop.BLL.PaymentVoucher.Enquiry
{
  public  interface IPaymentVoucherEnquiryFunc
    {
       PaymentVoucherResponse GetAllPaymentVoucher();
       PaymentVoucherIDResponse GetPaymentVoucherByID(int id);
    }
}
