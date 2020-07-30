using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
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
        public IEnumerable<CategoryDTO> GetAllCategory()
        {
            // Get Data From DB
            var categories = _unitOfWork.CategoryRepository.GetAll();
            // Map Result
            var categoryDTO = _categoryMappingResponse.MapCategoryDBModelToDTO(categories);
            return categoryDTO;
        }

        public CategoryDTO GetCategoryById(int id)
        {
            // Get Data
            var category = _unitOfWork.CategoryRepository.GetById(id);
            // Map Result
            var categoryDTO = _categoryMappingResponse.MapCategoryDBModelToDTO(category);
            return categoryDTO;
        }
    }
}
