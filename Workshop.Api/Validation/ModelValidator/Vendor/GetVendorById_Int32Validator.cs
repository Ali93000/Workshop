using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Api.Validation.ModelValidator
{
    public class GetVendorById_Int32Validator : AbstractValidator<Int32>
    {
        public GetVendorById_Int32Validator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("Id Is Required")
                .Must(BeValidNumber).WithMessage("Please Insert Valid Id");
        }

        private bool BeValidNumber(int id)
        {
            if (id <= 0 || id > Int32.MaxValue)
                return false;
            return true;
        }
    }
}