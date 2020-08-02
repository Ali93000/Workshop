using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.Category;

namespace Workshop.Entities.ApiModels.Category.Response
{
    public class CategoryResponse : GenericResponse
    {
        public CategoryResponse()
        {
            Category = new CategoryDTO();
        }
        public CategoryDTO Category { get; set; }
    }
}
