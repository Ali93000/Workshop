using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.DTO.Category;

namespace Workshop.UI.Models.Category
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