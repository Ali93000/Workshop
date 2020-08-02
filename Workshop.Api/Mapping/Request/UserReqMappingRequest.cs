using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Request;
using Workshop.Entities.ApiModels.User.Request;

namespace Workshop.Api.Mapping.Request
{
    public class UserReqMappingRequest : IUserReqMappingRequest
    {
        private readonly IUserMapperConfiguration _userMapperConfiguration;
        public UserReqMappingRequest(IUserMapperConfiguration userMapperConfiguration)
        {
            this._userMapperConfiguration = userMapperConfiguration;
        }
        public G_USERS MapFromUserReqToUserDBModel(UserLoginReq userReq)
        {
            return _userMapperConfiguration.GetMapper().Map<G_USERS>(userReq);
        }
    }
}