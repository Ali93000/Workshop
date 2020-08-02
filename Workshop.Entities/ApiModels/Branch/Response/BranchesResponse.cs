using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.Branch;

namespace Workshop.Entities.ApiModels.Branch.Response
{
    public class BranchesResponse : GenericResponse
    {
        public BranchesResponse()
        {
            BranchesList = new List<BranchDTO>();
        }
        public List<BranchDTO> BranchesList { get; set; }
    }
}
