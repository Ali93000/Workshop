using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Branch.Response;

namespace Workshop.BLL.Branch.Enquiry
{
    public class BranchEnquiryFunc : IBranchEnquiryFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBranchMappingResponse _branchMappingResponse;
        public BranchEnquiryFunc(IUnitOfWork unitOfWork, IBranchMappingResponse branchMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._branchMappingResponse = branchMappingResponse;
        }
        public BranchesResponse GetAllBranches()
        {
            // Get Data From DB
            var branches = _unitOfWork.BranchRepository.GetAll();
            if (branches == null)
            {
                return new BranchesResponse { IsSuccessful = false, BranchesList = null, ResponseCode = System.Net.HttpStatusCode.NotFound, ResponseMessages = new List<string> { "No Data Found" } };
            }
            // Map Result
            var branchesDTO = _branchMappingResponse.MapFromBranchDbToDTO(branches);
            return branchesDTO;
        }

        public BranchesResponse GetAllBranches(int? compId)
        {
            // Get Data From DB
            var branches = _unitOfWork.BranchRepository.Get(c=>c.CompCode == compId);
            if (branches == null)
            {
                return new BranchesResponse { IsSuccessful = false, BranchesList = null, ResponseCode = System.Net.HttpStatusCode.NotFound, ResponseMessages = new List<string> { "No Data Found" } };
            }
            // Map Result
            var branchesDTO = _branchMappingResponse.MapFromBranchDbToDTO(branches);
            return branchesDTO;
        }
    }
}
