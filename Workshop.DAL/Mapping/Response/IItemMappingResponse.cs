using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Item.Response;
using Workshop.Entities.DTO;

namespace Workshop.DAL.Mapping.Response
{
    public interface IItemMappingResponse
    {
        ItemsResponse MapFromDBModelToDTO(IEnumerable<W_D_Items> items);
        ItemResponse MapFromDBModelToDTO(W_D_Items item);
    }
}
