using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.DTO.Branch;

namespace Workshop.UI.Models.Branch
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