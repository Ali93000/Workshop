using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.ApiModels.CashReceipt.Request
{
   public class ReceiptVoucherReq
    {
        public int Id { get; set; }
        public int TrCode { get; set; }
        public Nullable<System.DateTime> TrDate { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<decimal> ReceiptTotal { get; set; }
        public Nullable<decimal> Amount_Paid { get; set; }
        public Nullable<decimal> Remaining_Amount { get; set; }
        public string Remark { get; set; }
    }
}
