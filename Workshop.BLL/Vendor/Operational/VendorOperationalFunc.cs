using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Mapping.Request;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Vendor.Request;

namespace Workshop.BLL.Vendor.Operational
{
    public class VendorOperationalFunc : IVendorOperationalFunc
    {
        private readonly IVendorReqMappingRequest _vendorReqMappingRequest;
        private readonly IUnitOfWork _unitOfWork;
        public VendorOperationalFunc(IVendorReqMappingRequest vendorReqMappingRequest, IUnitOfWork unitOfWork)
        {
            this._vendorReqMappingRequest = vendorReqMappingRequest;
            this._unitOfWork = unitOfWork;
        }
        public int CreateVendor(VendorReq vendorReq)
        {
            // Map From Vendor Req to W_D_Vendor
            var vendorDB = _vendorReqMappingRequest.MapFromVendorReqToVendorDB(vendorReq);
            // Insert In To DB
            _unitOfWork.VendorRepository.Add(vendorDB);
            _unitOfWork.SaveChanges();
            return vendorDB.Id;
        }

        public void DeleteVendor(int id)
        {
            _unitOfWork.VendorRepository.RemoveById(id);
            _unitOfWork.SaveChanges();
        }

        public void UpdateVendor(VendorReq vendorReq)
        {
            // Map From Vendor Req to W_D_Vendor
            var vendorDB = _vendorReqMappingRequest.MapFromVendorReqToVendorDB(vendorReq);
            // Insert In To DB
            _unitOfWork.VendorRepository.Update(vendorDB);
            _unitOfWork.SaveChanges();
        }
    }
}
