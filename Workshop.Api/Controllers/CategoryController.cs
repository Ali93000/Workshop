using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workshop.Api.Helpers;
using Workshop.Api.Validation.Configuration;
using Workshop.BLL.Category.Enquiry;
using Workshop.BLL.Category.Operational;
using Workshop.Entities.ApiModels.Category;

namespace Workshop.Api.Controllers
{
    public class CategoryController : ApiController
    {
        // User Privilages
        // 
        private readonly ICategoryEnquiryFunc _categoryEnquiryFunc;
        private readonly IModelStateValidator _modelStateValidator;
        private readonly ICategoryOperationalFunc _categoryOperationalFunc;
        
        public CategoryController(ICategoryEnquiryFunc categoryEnquiryFunc, IModelStateValidator modelStateValidator, ICategoryOperationalFunc categoryOperationalFunc)
        {
            this._categoryEnquiryFunc = categoryEnquiryFunc;
            this._modelStateValidator = modelStateValidator;
            this._categoryOperationalFunc = categoryOperationalFunc;
        }

        [HttpGet, Route("api/v1/category")]
        public IHttpActionResult GetAllCategories()
        {
            // Run BLL
            var categories = _categoryEnquiryFunc.GetAllCategory();
            return new WorkHttpActionResult(categories, HttpStatusCode.OK);
        }

        [HttpGet, Route("api/v1/category/{id}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            // Validate Model 
            var isValid = _modelStateValidator.ValidateModel(id);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            var category = _categoryEnquiryFunc.GetCategoryById(id);
            return new WorkHttpActionResult(category, HttpStatusCode.OK);
        }


        [HttpPost, Route("api/v1/category")]
        public IHttpActionResult CreateCategory(CategoryReq categoryReq)
        {
            // Validate Model
            var isValid = _modelStateValidator.ValidateModel(categoryReq);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            var catId = _categoryOperationalFunc.CreateCategory(categoryReq);
            return new WorkHttpActionResult($"Category CareatedWith Id = {catId}", HttpStatusCode.Created);
        }

        [HttpPut, Route("api/v1/category")]
        public IHttpActionResult UpdateCategory(CategoryReq categoryReq)
        {
            // Validate Model
            var isValid = _modelStateValidator.ValidateModel(categoryReq);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            _categoryOperationalFunc.UpdateCategory(categoryReq);
            return new WorkHttpActionResult("Category Updated Successfully", HttpStatusCode.OK);
        }

        [HttpDelete, Route("api/v1/category")]
        public IHttpActionResult DeleteCategory(int id)
        {
            // Validate Model
            var isValid = _modelStateValidator.ValidateModel(id);
            if (isValid != null)
            {
                return new WorkHttpActionResult(isValid, isValid.ResponseCode);
            }
            // Run BLL
            _categoryOperationalFunc.DeleteCategory(id);
            return new WorkHttpActionResult("Category Deleted Successfully", HttpStatusCode.OK);
        }
    }
}
