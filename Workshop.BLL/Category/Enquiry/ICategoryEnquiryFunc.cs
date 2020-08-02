using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Category.Response;
using Workshop.Entities.DTO.Category;

namespace Workshop.BLL.Category.Enquiry
{
    public interface ICategoryEnquiryFunc
    {
        CategoriesResponse GetAllCategory();
        CategoryResponse GetCategoryById(int id);
    }
}
