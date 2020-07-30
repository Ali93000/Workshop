using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Request;
using Workshop.Entities.ApiModels.Category;

namespace Workshop.Api.Mapping.Request
{
    public class CategoryReqMappingRequest : ICategoryReqMappingRequest
    {
        private readonly ICategoryMapperConfiguration _categoryMapperConfiguration;
        public CategoryReqMappingRequest(ICategoryMapperConfiguration categoryMapperConfiguration)
        {
            this._categoryMapperConfiguration = categoryMapperConfiguration;
        }
        public W_D_Category MapFromCategoryReqToCategoryDB(CategoryReq categoryReq)
        {
            return _categoryMapperConfiguration.GetMapper().Map<W_D_Category>(categoryReq);
        }
    }
}