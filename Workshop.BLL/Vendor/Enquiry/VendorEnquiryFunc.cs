using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Vendor;
using Workshop.Entities.ApiModels.Vendor.Response;

namespace Workshop.BLL.Vendor.Enquiry
{
    public class VendorEnquiryFunc : IVendorEnquiryFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVendorMappingResponse _vendorMappingResponse;
        public VendorEnquiryFunc(IUnitOfWork unitOfWork, IVendorMappingResponse vendorMappingResponse)
        {
            _unitOfWork = unitOfWork;
            this._vendorMappingResponse = vendorMappingResponse;
        }
        public VendorsResponse GetAllVendor()
        {
            // Get List Of Vendors From DB
            var vendors = _unitOfWork.VendorRepository.GetAll();
            if (vendors == null)
            {
                return new VendorsResponse { IsSuccessful = false, ResponseCode = System.Net.HttpStatusCode.NotFound, VendorsList = null, ResponseMessages = new List<string> { "No Data Found" } };
            }
            // Map Result To DTO
            var vendorResponse = _vendorMappingResponse.MapFromDBModelToVendorDTOResponse(vendors);
            vendorResponse.IsSuccessful = true;
            vendorResponse.ResponseCode = System.Net.HttpStatusCode.OK;
            return vendorResponse;
        }

        public VendorResponse GetVendorById(int id)
        {
            // Get Data From DB
            var vendor = _unitOfWork.VendorRepository.GetById(id);
            if (vendor == null)
            {
                return new VendorResponse { IsSuccessful = false, ResponseCode = System.Net.HttpStatusCode.NotFound, ResponseMessages = new List<string> { "No Data Found" }, Vendor = null };
            }
            // Map Result To DTO
            var vendorDto = _vendorMappingResponse.MapFromDBModelToVendorDTOResponse(vendor);
            vendorDto.IsSuccessful = true;
            vendorDto.ResponseCode = System.Net.HttpStatusCode.OK;
            return vendorDto;
        }
        //public bool isMobil(string _mobil)
        //{
        //    return _unitOfWork.VendorRepository.isMonil(_mobil);
        //}
    }
}
