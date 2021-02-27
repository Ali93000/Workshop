using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Mapping.Request;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Services.Request;

namespace Workshop.BLL.Services.Operational
{
    public class ServicesOperationalFunc : IServicesOperationalFunc
    {
        private readonly IServicesReqMappingRequest _servicesReqMappingRequest;
        private readonly IUnitOfWork _unitOfWork;
        public ServicesOperationalFunc(IServicesReqMappingRequest servicesReqMappingRequest, IUnitOfWork unitOfWork)
        {
            this._servicesReqMappingRequest = servicesReqMappingRequest;
            this._unitOfWork = unitOfWork;
        }
        public int CreateServices(ServicesReq servicesReq)
        {
            // Map From Services REQ to W_D_Services DB
            var servicesDb = _servicesReqMappingRequest.mapFromSevicesReqToMapDB(servicesReq);
            // Insert To Data Base
            _unitOfWork.ServicesRepository.Add(servicesDb);
            _unitOfWork.SaveChanges();
            return servicesDb.Id;
        }

        public void DeteteServices(int id)
        {
                  // Delete From DB
            _unitOfWork.ServicesRepository.RemoveById(id);
            _unitOfWork.SaveChanges();
        }

        public void UpdateServices(ServicesReq servicesReq)
        {
            // Map From ServicesReq To DB
            var servicesDb = _servicesReqMappingRequest.mapFromSevicesReqToMapDB(servicesReq);
            // Edit To DataBASE
            _unitOfWork.ServicesRepository.Update(servicesDb);
            _unitOfWork.SaveChanges();
        }
    }
}
