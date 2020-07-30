using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.DTO.Category;

namespace Workshop.BLL.Category.Enquiry
{
    public interface ICategoryEnquiryFunc
    {
        IEnumerable<CategoryDTO> GetAllCategory();
        CategoryDTO GetCategoryById(int id);
    }
}
