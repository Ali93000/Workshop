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
    
    public partial class G_Branches
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public G_Branches()
        {
            this.G_USERS_BRANCHES = new HashSet<G_USERS_BRANCHES>();
        }
    
        public int BraCode { get; set; }
        public string BraDesAr { get; set; }
        public string BraDesEn { get; set; }
        public string City { get; set; }
        public string BraAddress { get; set; }
        public string BraTel { get; set; }
        public string BraTel2 { get; set; }
        public string BraFax { get; set; }
        public string BraEmail { get; set; }
        public string BranchManager { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CompCode { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual G_Companies G_Companies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<G_USERS_BRANCHES> G_USERS_BRANCHES { get; set; }
    }
}
