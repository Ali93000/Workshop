using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO;

namespace Workshop.Entities.ApiModels.Item.Response
{
    public class ItemResponse : GenericResponse
    {
        public ItemResponse()
        {
            Item = new ItemDTO();
        }
        public ItemDTO Item { get; set; }
    }
}
