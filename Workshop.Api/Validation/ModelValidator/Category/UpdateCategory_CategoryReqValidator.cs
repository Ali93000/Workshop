using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.Category;

namespace Workshop.Api.Validation.ModelValidator
{
    public class UpdateCategory_CategoryReqValidator : AbstractValidator<CategoryReq>
    {
        public UpdateCategory_CategoryReqValidator()
        {
            RuleFor(x => x.Id)
               .GreaterThanOrEqualTo(0).WithMessage("Please Insert Valid Id")
               .NotEmpty().WithMessage("Id Is Required to Complete Update Process");
            RuleFor(c => c.CategoryNameAr)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(c => c.CategoryNameEn)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
        }
    }
}