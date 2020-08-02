using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.Entities.ApiModels.User.Response;

namespace Workshop.Api.Mapping.Response
{
    public class UserMappingResponse : IUserMappingResponse
    {
        private readonly IUserMapperConfiguration _userMapperConfiguration;
        public UserMappingResponse(IUserMapperConfiguration userMapperConfiguration)
        {
            this._userMapperConfiguration = userMapperConfiguration;
        }
        public UserLoginInfoResponse MapGUserFromDBToUserLoginResponse(G_USERS g_USERS)
        {
            return _userMapperConfiguration.GetMapper().Map<UserLoginInfoResponse>(g_USERS);
        }
    }
}