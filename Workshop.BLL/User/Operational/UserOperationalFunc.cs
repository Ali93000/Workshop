using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.User.Request;
using Workshop.Entities.ApiModels.User.Response;

namespace Workshop.BLL.User.Operational
{
    public class UserOperationalFunc : IUserOperationalFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserOperationalFunc(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

    }
}
