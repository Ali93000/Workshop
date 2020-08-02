using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Api.Mapping.AutomapperConfiguration.Interfaces;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Request;
using Workshop.Entities.ApiModels.Item;

namespace Workshop.Api.Mapping.Request
{
    public class ItemReqMappingRequest : IItemReqMappingRequest
    {
        private readonly IItemMapperConfiguration _itemMapperConfiguration;

        public ItemReqMappingRequest(IItemMapperConfiguration itemMapperConfiguration)
        {
            this._itemMapperConfiguration = itemMapperConfiguration;
        }

        public W_D_Items MapFromItemReqToDBMOdel(ItemReq itemReq)
        {
            return _itemMapperConfiguration.GetMapper().Map<W_D_Items>(itemReq);
        }
    }
}