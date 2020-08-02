using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.Branch;

namespace Workshop.Entities.ApiModels.Branch.Response
{
    public class BranchResponse : GenericResponse
    {
        public BranchResponse()
        {
            Branch = new BranchDTO();
        }
        public BranchDTO Branch { get; set; }
    }
}
