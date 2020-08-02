using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Item;
using Workshop.Entities.ApiModels.Item.Response;
using Workshop.Entities.DTO;

namespace Workshop.Api.Mapping.AutomapperConfiguration.Implementation
{
    public class ItemMapperConfiguration : IItemMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<W_D_Items, ItemDTO>()
                .ForMember(des=> des.CategoryName, map =>
                map.MapFrom(src =>src.W_D_Category.CategoryNameAr))
                .ForMember(des => des.VendorName, map=>
                map.MapFrom(src =>src.W_D_Vendor.VerndorNameAr));

                cfg.CreateMap<ItemReq, W_D_Items>();

                cfg.CreateMap<W_D_Items, ItemResponse>()
                .ForMember(des => des.Item, map=>
                map.MapFrom(src => src));


                cfg.CreateMap<IEnumerable<W_D_Items>, ItemsResponse>()
                .ForMember(des => des.ItemsList, map =>
                 map.MapFrom(src => src));
            });
            return config.CreateMapper();
        }
    }
}