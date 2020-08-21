using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.DTO.CachReceipt
{
    public class ReceiptVoucherDTO
    {
        public int Id { get; set; }
        public int TrCode { get; set; }
        public Nullable<System.DateTime> TrDate { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<decimal> Receipt_Total { get; set; }
        public Nullable<decimal> Amount_Paid { get; set; }
        public Nullable<decimal> Remaining_Amount { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> CreateAt { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<int> CompanyCode { get; set; }
        public Nullable<int> BranchCode { get; set; }


    }
}
