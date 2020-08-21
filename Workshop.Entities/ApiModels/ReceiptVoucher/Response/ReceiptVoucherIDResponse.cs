using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.CachReceipt;

namespace Workshop.Entities.ApiModels.CashReceipt.Response
{
   public class ReceiptVoucherIDResponse : GenericResponse
    {
        public ReceiptVoucherDTO CachReceiptID { get; set; }
        public ReceiptVoucherIDResponse()
        {
            CachReceiptID = new ReceiptVoucherDTO();
        }
    }
}
