using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.User;

namespace Workshop.Entities.ApiModels.User.Response
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
