using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Category;
using Workshop.Entities.ApiModels.Category.Response;
using Workshop.Entities.DTO.Category;

namespace Workshop.Api.Mapping.AutomapperConfiguration.Implementation
{
    public class CategoryMapperConfiguration : ICategoryMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<W_D_Category, CategoryDTO>();

                cfg.CreateMap<CategoryReq, W_D_Category>();

                cfg.CreateMap<IEnumerable<W_D_Category>, CategoriesResponse>()
                .ForMember(des => des.CategoriesList, map =>
                map.MapFrom(src => src));
                
                cfg.CreateMap<W_D_Category, CategoryResponse>()
                .ForMember(des => des.Category, map =>
                map.MapFrom(src => src));
            });
            return config.CreateMapper();
        }
    }
}