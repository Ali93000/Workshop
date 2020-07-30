using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.Category;

namespace Workshop.Api.Validation.ModelValidator
{
    public class CreateCategory_CategoryReqValidator : AbstractValidator<CategoryReq>
    {
        public CreateCategory_CategoryReqValidator()
        {
            RuleFor(c => c.CategoryNameAr)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(c => c.CategoryNameEn)
                .NotEmpty().WithMessage("{PropertyName} Is Required");

        }
    }
}