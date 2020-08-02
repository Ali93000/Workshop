using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.Entities.ApiModels.Item.Response;
using Workshop.Entities.DTO;

namespace Workshop.Api.Mapping.Response
{
    public class ItemMappingResponse : IItemMappingResponse
    {
        private readonly IItemMapperConfiguration _itemMapperConfiguration;
        public ItemMappingResponse(IItemMapperConfiguration itemMapperConfiguration)
        {
            this._itemMapperConfiguration = itemMapperConfiguration;
        }
        public ItemsResponse MapFromDBModelToDTO(IEnumerable<W_D_Items> items)
        {
            //return _itemMapperConfiguration.GetMapper().Map<IEnumerable<ItemDTO>>(items);
            return _itemMapperConfiguration.GetMapper().Map<ItemsResponse>(items);
        }

        public ItemResponse MapFromDBModelToDTO(W_D_Items item)
        {
            //return _itemMapperConfiguration.GetMapper().Map<ItemDTO>(item);
            return _itemMapperConfiguration.GetMapper().Map<ItemResponse>(item);
        }
    }
}