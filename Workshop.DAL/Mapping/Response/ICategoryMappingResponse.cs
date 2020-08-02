using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Category.Response;
using Workshop.Entities.DTO.Category;

namespace Workshop.DAL.Mapping.Response
{
    public interface ICategoryMappingResponse
    {
        CategoriesResponse MapCategoryDBModelToDTO(IEnumerable<W_D_Category> category);
        CategoryResponse MapCategoryDBModelToDTO(W_D_Category category);
    }
}
