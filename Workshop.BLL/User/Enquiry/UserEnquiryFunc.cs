using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.User.Request;
using Workshop.Entities.ApiModels.User.Response;

namespace Workshop.BLL.User.Enquiry
{
    public class UserEnquiryFunc : IUserEnquiryFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserMappingResponse _userMappingResponse;
        public UserEnquiryFunc(IUnitOfWork unitOfWork, IUserMappingResponse userMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._userMappingResponse = userMappingResponse;
        }
        public UserLoginInfoResponse UserLogin(UserLoginReq userLoginReq)
        {
            // Get Data From DB
            var userInfo = _unitOfWork.UserRepository
                .UserLoginData(c => c.Username == userLoginReq.Username && c.UserPassword == userLoginReq.Password);
            if (userInfo == null)
            {
                return new UserLoginInfoResponse { IsSuccessful = false, ResponseCode = System.Net.HttpStatusCode.NotFound, UserLoginInfo = null, ResponseMessages = new List<string> { "No Data Found" } };
            }
            //Map Result
            var userResponse = _userMappingResponse.MapGUserFromDBToUserLoginResponse(userInfo);
            userResponse.IsSuccessful = true;
            userResponse.ResponseCode = System.Net.HttpStatusCode.OK;
            return userResponse;
        }
    }
}
