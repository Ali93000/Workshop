using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.PaymentVoucher;

namespace Workshop.Entities.ApiModels.PaymentVoucher.Response
{
   public class PaymentVoucherResponse :GenericResponse
    {
        public PaymentVoucherResponse()
        {
            PaymentVoucherList = new List<PaymentVoucherDTO>();
        }
        public List<PaymentVoucherDTO> PaymentVoucherList { get; set; }
    }
}
