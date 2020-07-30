using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Category;

namespace Workshop.BLL.Category.Operational
{
    public interface ICategoryOperationalFunc
    {
        int CreateCategory(CategoryReq categoryReq);
        void UpdateCategory(CategoryReq categoryReq);
        void DeleteCategory(int id);
    }
}
