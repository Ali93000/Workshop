using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.CachReceipt;
using Workshop.Entities.DTO.PaymentVoucher;

namespace Workshop.Entities.ApiModels.CashReceipt.Response
{
   public class ReceiptVoucherResponse : GenericResponse
    {
        public ReceiptVoucherResponse()
        {
            cachReceiptList = new List<ReceiptVoucherDTO>();
        }
        public List<ReceiptVoucherDTO> cachReceiptList { get; set; }
     
       
    }
}
