using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.DTO.PaymentVoucher
{
  public  class PaymentVoucherDTO
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
        public string CreateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<int> CompanyCode { get; set; }
        public Nullable<int> BranchCode { get; set; }
    }
}
