using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.Entities.ApiModels.Category.Response;
using Workshop.Entities.DTO.Category;

namespace Workshop.Api.Mapping.Response
{
    public class CategoryMappingResponse : ICategoryMappingResponse
    {
        private readonly ICategoryMapperConfiguration _categoryMapperConfiguration;
        public CategoryMappingResponse(ICategoryMapperConfiguration categoryMapperConfiguration)
        {
            this._categoryMapperConfiguration = categoryMapperConfiguration;
        }

        public CategoriesResponse MapCategoryDBModelToDTO(IEnumerable<W_D_Category> category)
        {
            return _categoryMapperConfiguration.GetMapper().Map<CategoriesResponse>(category);
        }

        public CategoryResponse MapCategoryDBModelToDTO(W_D_Category category)
        {
            return _categoryMapperConfiguration.GetMapper().Map<CategoryResponse>(category);
        }
    }
}