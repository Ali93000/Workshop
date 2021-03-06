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
    
    public partial class G_USERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public G_USERS()
        {
            this.G_USERS_BRANCHES = new HashSet<G_USERS_BRANCHES>();
        }
    
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string UserCity { get; set; }
        public string UserAddress { get; set; }
        public string UserTel1 { get; set; }
        public string UserMobile { get; set; }
        public string UserEmail { get; set; }
        public string DepartmentName { get; set; }
        public string JobTitle { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<bool> IsManager { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CompCode { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual G_Companies G_Companies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<G_USERS_BRANCHES> G_USERS_BRANCHES { get; set; }
        public virtual UserRoles UserRoles { get; set; }
    }
}
