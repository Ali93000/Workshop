using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Category.Response;
using Workshop.Entities.DTO.Category;

namespace Workshop.BLL.Category.Enquiry
{
    public class CategoryEnquiryFunc : ICategoryEnquiryFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryMappingResponse _categoryMappingResponse;
        public CategoryEnquiryFunc(IUnitOfWork unitOfWork, ICategoryMappingResponse categoryMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._categoryMappingResponse = categoryMappingResponse;
        }
        public CategoriesResponse GetAllCategory()
        {
            // Get Data From DB
            var categories = _unitOfWork.CategoryRepository.GetAll();
            if (categories == null)
            {
                return new CategoriesResponse { IsSuccessful = false, CategoriesList = null, ResponseCode = System.Net.HttpStatusCode.NotFound, ResponseMessages = new List<string> { "No Data Found" } };
            }
            // Map Result
            var categoryDTO = _categoryMappingResponse.MapCategoryDBModelToDTO(categories);
            categoryDTO.IsSuccessful = true;
            categoryDTO.ResponseCode = System.Net.HttpStatusCode.OK;
            return categoryDTO;
        }

        public CategoryResponse GetCategoryById(int id)
        {
            // Get Data
            var category = _unitOfWork.CategoryRepository.GetById(id);
            if (category == null)
            {
                return new CategoryResponse { IsSuccessful = false, ResponseCode = System.Net.HttpStatusCode.NotFound, Category = null, ResponseMessages = new List<string> { "No Data Found" } };
            }
            // Map Result
            var categoryDTO = _categoryMappingResponse.MapCategoryDBModelToDTO(category);
            categoryDTO.IsSuccessful = true;
            categoryDTO.ResponseCode = System.Net.HttpStatusCode.OK;
            return categoryDTO;
        }
    }
}
