using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.Entities.ApiModels.Branch.Response;

namespace Workshop.Api.Mapping.Response
{
    public class BranchMappingResponse : IBranchMappingResponse
    {
        private readonly IBranchMapperConfiguration _branchMapperConfiguration;
        public BranchMappingResponse(IBranchMapperConfiguration branchMapperConfiguration)
        {
            this._branchMapperConfiguration = branchMapperConfiguration;
        }
        public BranchesResponse MapFromBranchDbToDTO(IEnumerable<G_Branches> branches)
        {
            return _branchMapperConfiguration.GetMapper().Map<BranchesResponse>(branches);
        }
    }
}