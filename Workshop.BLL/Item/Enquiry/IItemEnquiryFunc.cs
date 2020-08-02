using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Item.Response;
using Workshop.Entities.DTO;

namespace Workshop.BLL.Item.Enquiry
{
    public interface IItemEnquiryFunc
    {
        ItemsResponse GetAllItems();
        //ItemDTO GetItemById(int id);
        ItemResponse GetItemById(int id);
    }
}
