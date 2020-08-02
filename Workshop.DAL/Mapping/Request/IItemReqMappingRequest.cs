using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Item;

namespace Workshop.DAL.Mapping.Request
{
    public interface IItemReqMappingRequest
    {
        W_D_Items MapFromItemReqToDBMOdel(ItemReq itemReq);
    }
}
