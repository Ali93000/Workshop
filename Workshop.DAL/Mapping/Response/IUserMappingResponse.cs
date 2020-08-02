using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.User.Response;

namespace Workshop.DAL.Mapping.Response
{
    public interface IUserMappingResponse
    {
        UserLoginInfoResponse MapGUserFromDBToUserLoginResponse(G_USERS g_USERS);
    }
}
