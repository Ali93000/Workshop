using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Api.Validation.ModelValidator
{
    public class GetItemById_Int32Validator : AbstractValidator<Int32>
    {
        public GetItemById_Int32Validator()
        {
            RuleFor(x => x)
                .Must(BeValidNumber).WithMessage("Please Send Valid Id");
        }

        private bool BeValidNumber(int id)
        {
            if (id <= 0 || id > Int32.MaxValue)
                return false;
            return true;
        }
    }
}