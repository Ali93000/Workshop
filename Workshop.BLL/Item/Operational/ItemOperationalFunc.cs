using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Request;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Item;

namespace Workshop.BLL.Item.Operational
{
    public class ItemOperationalFunc : IItemOperationalFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemReqMappingRequest _itemReqMappingRequest;
        public ItemOperationalFunc(IUnitOfWork unitOfWork, IItemReqMappingRequest itemReqMappingRequest)
        {
            this._unitOfWork = unitOfWork;
            this._itemReqMappingRequest = itemReqMappingRequest;
        }
        public int CreateItem(ItemReq itemReq)
        {
            // Map itemReq to W_D_Item
            var item = _itemReqMappingRequest.MapFromItemReqToDBMOdel(itemReq);
            // Run BLL
            _unitOfWork.ItemRepository.Add(item);
            _unitOfWork.SaveChanges();
            return item.Id;
        }

        public void DeleteItem(int id)
        {
            _unitOfWork.ItemRepository.RemoveById(id);
            _unitOfWork.SaveChanges();
        }

        public void UpdateItem(ItemReq itemReq)
        {
            // Map Model
            var itemDB = _itemReqMappingRequest.MapFromItemReqToDBMOdel(itemReq);
            // Run BLL
            _unitOfWork.ItemRepository.Update(itemDB);
            _unitOfWork.SaveChanges();
        }
    }
}
