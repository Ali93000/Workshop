//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Workshop.DAL.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class W_D_Vendor
    {
        public int Id { get; set; }
        public string VendorCode { get; set; }
        public string VerndorName { get; set; }
        public string ResponsibleName { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string VatNo { get; set; }
        public string VatType { get; set; }
        public string VendorAddress { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<int> CompCode { get; set; }
        public Nullable<int> BranchCode { get; set; }
    }
}
