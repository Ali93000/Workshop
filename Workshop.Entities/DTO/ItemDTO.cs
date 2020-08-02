using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescAr { get; set; }
        public string ItemDescEn { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> ItemPurchPrice { get; set; }
        public Nullable<decimal> SellingPrice { get; set; }
        public Nullable<decimal> LowestSellingPrice { get; set; }
        public Nullable<System.DateTime> PurchDate { get; set; }
        public string ItemImage { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Remarks { get; set; }
        public string MadeInCountry { get; set; }
        public Nullable<int> CompCode { get; set; }
        public Nullable<int> BraCode { get; set; }
        public Nullable<int> VendorId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string CategoryName { get; set; }
        public string VendorName { get; set; }
    }
}
