using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.Item;

namespace Workshop.BLL.Item.Operational
{
    public interface IItemOperationalFunc
    {
        int CreateItem(ItemReq itemReq);
        void UpdateItem(ItemReq itemReq);
        void DeleteItem(int id);
    }
}
