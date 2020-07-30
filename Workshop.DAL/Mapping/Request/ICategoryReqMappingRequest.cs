using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Category;

namespace Workshop.DAL.Mapping.Request
{
    public interface ICategoryReqMappingRequest
    {
        W_D_Category MapFromCategoryReqToCategoryDB(CategoryReq categoryReq);
    }
}
