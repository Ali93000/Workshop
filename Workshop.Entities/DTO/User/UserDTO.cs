using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.DTO.User
{
    public class UserDTO
    {
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
        public string RoleName { get; set; }
        public Nullable<bool> IsManager { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CompCode { get; set; }
        public Nullable<int> BraCode { get; set; }
        public string CompName { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
