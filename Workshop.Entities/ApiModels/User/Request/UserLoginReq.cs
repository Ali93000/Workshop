using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.ApiModels.User.Request
{
    public class UserLoginReq
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
