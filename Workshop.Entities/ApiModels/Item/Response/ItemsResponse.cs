using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO;

namespace Workshop.Entities.ApiModels.Item.Response
{
    public class ItemsResponse : GenericResponse
    {
        public ItemsResponse()
        {
            ItemsList = new List<ItemDTO>();
        }
        public List<ItemDTO> ItemsList { get; set; }
    }
}
