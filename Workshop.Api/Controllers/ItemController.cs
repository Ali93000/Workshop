using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Helpers;
using Workshop.Api.Validation.Configuration;
using Workshop.BLL.Item.Enquiry;
using Workshop.BLL.Item.Operational;
using Workshop.Entities.ApiModels.Item;

namespace Workshop.Api.Controllers
{
    public class ItemController : ApiController
    {
        private readonly IItemEnquiryFunc _itemEnquiryFunc;
        private readonly IModelStateValidator _modelStateValidator;
        private readonly IItemOperationalFunc _itemOperationaFunc;
        public ItemController(IItemEnquiryFunc itemEnquiryFunc, IModelStateValidator modelStateValidator, IItemOperationalFunc itemOperationaFunc)
        {
            this._itemEnquiryFunc = itemEnquiryFunc;
            this._modelStateValidator = modelStateValidator;
            this._itemOperationaFunc = itemOperationaFunc;
        }
        [HttpGet, Route("api/v1/item")]
        public IHttpActionResult GetAllItems()
        {
            // Run BLL
            var items = _itemEnquiryFunc.GetAllItems();
            return new WorkHttpActionResult(items, HttpStatusCode.OK);
        }

        [HttpGet, Route("api/v1/item/{id}")]
        public IHttpActionResult GetItemById(int id)
        {
            // Validate Model
            var isValid = _modelStateValidator.ValidateModel(id);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run Bll
            var item = _itemEnquiryFunc.GetItemById(id);
            return new WorkHttpActionResult(item, HttpStatusCode.OK);
        }

        [HttpPost, Route("api/v1/item")]
        public IHttpActionResult CreateItem(ItemReq itemReq)
        {
            // Validate Model
            var isValid = _modelStateValidator.ValidateModel(itemReq);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            int itemId = _itemOperationaFunc.CreateItem(itemReq);
            return new WorkHttpActionResult($"Item Created With Id = {itemId}", HttpStatusCode.Created);
        }

        [HttpPut, Route("api/v1/item")]
        public IHttpActionResult UpdateItem(ItemReq itemReq)
        {
            // Validate Model
            var isValid = _modelStateValidator.ValidateModel(itemReq);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            _itemOperationaFunc.UpdateItem(itemReq);
            return new WorkHttpActionResult("Item Updated Successfully", HttpStatusCode.OK);
        }

        [HttpDelete, Route("api/v1/item")]
        public IHttpActionResult DeleteItem(int id)
        {
            var isValid = _modelStateValidator.ValidateModel(id);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            _itemOperationaFunc.DeleteItem(id);
            return new WorkHttpActionResult("Item Deleted", HttpStatusCode.OK);
        }
    }
}
