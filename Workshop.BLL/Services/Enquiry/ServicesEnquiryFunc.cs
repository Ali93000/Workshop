using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Services.Response;

namespace Workshop.BLL.Services.Enquiry
{
    public class ServicesEnquiryFunc : IServicesEnquiryFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServicesrMappingResponse _servicesrMappingResponse;
        public ServicesEnquiryFunc(IUnitOfWork unitOfWork,IServicesrMappingResponse servicesrMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._servicesrMappingResponse = servicesrMappingResponse;
        }
        public ServicesResponse GetAllServices()
        {
            // Get List Services From DB
            var servicse = _unitOfWork.ServicesRepository.GetAll();
            if (servicse==null)
            {
                return new ServicesResponse { IsSuccessful = false, ResponseCode = System.Net.HttpStatusCode.NotFound, servicesList = null, ResponseMessages = new List<string> { "Not Found" } };
            }
            // Map Result To DTO
            var servicesResponse = _servicesrMappingResponse.mapFromDbToServicesDTO(servicse);
            servicesResponse.IsSuccessful = true;
            servicesResponse.ResponseCode = System.Net.HttpStatusCode.OK;
            return servicesResponse;
        }

        public ServicesIDResponse GetServicesByID(int id)
        {
            // GET Services BY ID From DB
            var servicesID = _unitOfWork.ServicesRepository.GetById(id);
            if (servicesID==null)
            {
                return new ServicesIDResponse { IsSuccessful = false, ResponseCode = System.Net.HttpStatusCode.NotFound, servicesId = null, ResponseMessages = new List<string> { "Not Found" } };
            }
            // Map Result To DTO
            var serviseidResponse = _servicesrMappingResponse.mapFromDbToServicesDTO(servicesID);
            serviseidResponse.IsSuccessful = true;
            serviseidResponse.ResponseCode = System.Net.HttpStatusCode.OK;
            return serviseidResponse;
        }
    }
}
