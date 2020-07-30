using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.DTO.Category;

namespace Workshop.DAL.Mapping.Response
{
    public interface ICategoryMappingResponse
    {
        IEnumerable<CategoryDTO> MapCategoryDBModelToDTO(IEnumerable<W_D_Category> category);
        CategoryDTO MapCategoryDBModelToDTO(W_D_Category category);
    }
}
