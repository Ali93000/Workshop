using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.PaymentVoucher;

namespace Workshop.Entities.ApiModels.PaymentVoucher.Response
{
  public  class PaymentVoucherIDResponse :GenericResponse
    {
        public PaymentVoucherIDResponse()
        {
            PaymentVoucherID = new PaymentVoucherDTO();
        }
        public PaymentVoucherDTO PaymentVoucherID { get; set; }
    }
}
