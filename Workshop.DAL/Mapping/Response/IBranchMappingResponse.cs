using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Branch.Response;

namespace Workshop.DAL.Mapping.Response
{
    public interface IBranchMappingResponse
    {
        BranchesResponse MapFromBranchDbToDTO(IEnumerable<G_Branches> branches);
    }
}
