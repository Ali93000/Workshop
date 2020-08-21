using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Helpers;
using Workshop.Api.Validation.Configuration;
using Workshop.BLL.Services.Enquiry;
using Workshop.BLL.Services.Operational;
using Workshop.Entities.ApiModels.Services.Request;

namespace Workshop.Api.Controllers
{
    public class ServicesController : ApiController
    {
        private readonly IServicesEnquiryFunc _servicesEnquiryFunc;
        private readonly IModelStateValidator _modelStateValidator;
        private readonly IServicesOperationalFunc _servicesOperationalFunc;

        public ServicesController(IServicesEnquiryFunc servicesEnquiryFunc, IModelStateValidator modelStateValidator,IServicesOperationalFunc servicesOperationalFunc)
        {
            this._servicesEnquiryFunc = servicesEnquiryFunc;
            this._modelStateValidator = modelStateValidator;
            this._servicesOperationalFunc = servicesOperationalFunc;
        }
        [HttpGet, Route("api/v1/services")]
        public IHttpActionResult GetAllServices()
        {
            //run BLL
            var services = _servicesEnquiryFunc.GetAllServices();
            return new WorkHttpActionResult(services, HttpStatusCode.OK);
        }
        [HttpGet, Route("api/v1/services/{id}")]
        public IHttpActionResult GetServicesById(int id)
        {
            //Validation Modle
            var isIdValid = _modelStateValidator.ValidateModel(id);
            if (isIdValid != null)
            {
                return new WorkHttpActionResult(isIdValid, isIdValid.ResponseCode);
            }
            // Run BLL
            var servicesId = _servicesEnquiryFunc.GetServicesByID(id);
            return new WorkHttpActionResult(servicesId, HttpStatusCode.OK);
        }
        [HttpPost,Route("api/v1/services")]
        public IHttpActionResult CreateServices(ServicesReq servicesReq)
        {
            //Validation Modle
            var isValid = _modelStateValidator.ValidateModel(servicesReq);
            if (isValid!=null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            //RUN BLL
            int servisecId = _servicesOperationalFunc.CreateServices(servicesReq);
            return new WorkHttpActionResult($"Vendor Created With Id {servicesReq}", HttpStatusCode.Created);
        }
        [HttpPut,Route("api/vi/services")]
        public IHttpActionResult UpdateServices(ServicesReq servicesReq )
        {
            // Validation Modle
            var isValidate = _modelStateValidator.ValidateModel(servicesReq);
            if (isValidate!= null)
            {
                return new WorkHttpActionResult(isValidate, isValidate.ResponseCode);
            }
            //RUN BLL
            _servicesOperationalFunc.UpdateServices(servicesReq);
            return new WorkHttpActionResult("servisec Is Update ", HttpStatusCode.OK);
        }
        [HttpDelete, Route("api/vi/services")]
        public IHttpActionResult DeleteServices(int id)
        {
            // validate Modle
            var isDeleteValidate = _modelStateValidator.ValidateModel(id);
            if (isDeleteValidate!= null)
            {
                return new WorkHttpActionResult(isDeleteValidate, isDeleteValidate.ResponseCode);
            }
            // run Bll
            _servicesOperationalFunc.DeteteServices(id);
            return new WorkHttpActionResult("Services is delete", HttpStatusCode.OK);
        }

        }
}

