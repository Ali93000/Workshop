using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.ApiModels.PaymentVoucher.Request
{
 public class PaymentVoucherReq
    {
        public int Id { get; set; }
        public int TrCode { get; set; }
        public Nullable<System.DateTime> TrDate { get; set; }
        public string Customer { get; set; }
        public Nullable<decimal> PaimentTotal { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> Cach { get; set; }
        public Nullable<bool> BankCheck { get; set; }
        public Nullable<bool> BankNetwork { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
    }
}
