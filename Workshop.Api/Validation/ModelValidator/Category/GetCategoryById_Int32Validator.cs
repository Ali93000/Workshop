using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Api.Validation.ModelValidator
{
    public class GetCategoryById_Int32Validator : AbstractValidator<Int32>
    {
        public GetCategoryById_Int32Validator()
        {
            RuleFor(x => x)
                .Must(CheckIdIsNumber)
                .WithMessage("Please Insert Valid Id Number");
        }

        public bool CheckIdIsNumber(int id)
        {
            if (id == 0 || id > Int32.MaxValue || id < 0)
                return false;
            return true;
        }
    }
}