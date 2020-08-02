using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.User.Request;

namespace Workshop.DAL.Mapping.Request
{
    public interface IUserReqMappingRequest
    {
        G_USERS MapFromUserReqToUserDBModel(UserLoginReq userReq);
    }
}
