using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Item.Response;
using Workshop.Entities.DTO;

namespace Workshop.BLL.Item.Enquiry
{
    public class ItemEnquiryFunc : IItemEnquiryFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemMappingResponse _itemMappingResponse;
        public ItemEnquiryFunc(IUnitOfWork unitOfWork, IItemMappingResponse itemMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._itemMappingResponse = itemMappingResponse;
        }

        public ItemsResponse GetAllItems()
        {
            // Get Data From DB
            var items = _unitOfWork.ItemRepository.GetAll();
            if (items == null)
            {
                return new ItemsResponse { IsSuccessful = false, ItemsList = null, ResponseCode = System.Net.HttpStatusCode.NotFound, ResponseMessages = new List<string> { "No data found" } };
            }
            // Mapping Result
            var itemsDTO = _itemMappingResponse.MapFromDBModelToDTO(items);
            itemsDTO.IsSuccessful = true;
            itemsDTO.ResponseCode = System.Net.HttpStatusCode.OK;
            return itemsDTO;
        }


        public ItemResponse GetItemById(int id)
        {
            // Get Data From DB
            var item = _unitOfWork.ItemRepository.GetById(id);
            if (item == null)
            {
                return new ItemResponse { IsSuccessful = false, ResponseCode = System.Net.HttpStatusCode.NotFound, ResponseMessages = new List<string> { "No data found" }, Item = null };
            }
            // Map Result
            var itemDTO = _itemMappingResponse.MapFromDBModelToDTO(item);
            itemDTO.IsSuccessful = true;
            itemDTO.ResponseCode = System.Net.HttpStatusCode.OK;
            return itemDTO;
        }
    }
}
