using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Api.Validation.ModelValidator
{
    public class GetCachReceiptById_Int32Validator : AbstractValidator<Int32>
    {
        public GetCachReceiptById_Int32Validator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("{PropertyName Is Reqauird}")
                .Must(idValid).WithMessage("Please Insert Valid Id");

        }

        private bool idValid(int id)
        {
            if (id <= 0 || id > Int32.MaxValue)
                return false;
            return true;
        }
    }
}