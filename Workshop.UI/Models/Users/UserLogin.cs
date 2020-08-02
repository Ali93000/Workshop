using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.UI.Models.Users
{
    public class UserLogin
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int CompCode { get; set; }
        public string CompName { get; set; }
        public int BraCode { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
    }
}