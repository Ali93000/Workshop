using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.DTO.User;

namespace Workshop.UI.Models.Users
{
    public class UserLoginInfoResponse : GenericResponse
    {
        public UserLoginInfoResponse()
        {
            UserLoginInfo = new UserDTO();
        }
        public UserDTO UserLoginInfo { get; set; }
    }
}