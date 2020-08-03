using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.ApiModels.Branch.Response;

namespace Workshop.BLL.Branch.Enquiry
{
    public interface IBranchEnquiryFunc
    {
        BranchesResponse GetAllBranches();
        BranchesResponse GetAllBranches(int? compId);
    }
}
