using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.Category;

namespace Workshop.Entities.ApiModels.Category.Response
{
    public class CategoriesResponse : GenericResponse
    {
        public CategoriesResponse()
        {
            CategoriesList = new List<CategoryDTO>();
        }
        public List<CategoryDTO> CategoriesList { get; set; }
    }
}
