using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Request;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Category;

namespace Workshop.BLL.Category.Operational
{
    public class CategoryOperationalFunc : ICategoryOperationalFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryReqMappingRequest _categoryReqMappingRequest;
        public CategoryOperationalFunc(IUnitOfWork unitOfWork, ICategoryReqMappingRequest categoryReqMappingRequest)
        {
            this._unitOfWork = unitOfWork;
            this._categoryReqMappingRequest = categoryReqMappingRequest;
        }
        public int CreateCategory(CategoryReq categoryReq)
        {
            // Map From CategoryReq to W_D_Category
            var categoryDB = _categoryReqMappingRequest.MapFromCategoryReqToCategoryDB(categoryReq);
            // Add in DB
            _unitOfWork.CategoryRepository.Add(categoryDB);
            _unitOfWork.SaveChanges();
            return categoryDB.Id;
        }

        public void DeleteCategory(int id)
        {
            _unitOfWork.CategoryRepository.RemoveById(id);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCategory(CategoryReq categoryReq)
        {
            // Map Model
            var categoryDB = _categoryReqMappingRequest.MapFromCategoryReqToCategoryDB(categoryReq);
            // Update To DB
            _unitOfWork.CategoryRepository.Update(categoryDB);
            _unitOfWork.SaveChanges();
        }
    }
}
