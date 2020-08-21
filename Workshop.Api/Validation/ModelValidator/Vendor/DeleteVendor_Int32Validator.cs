using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Api.Validation.ModelValidator
{
    public class DeleteVendor_Int32Validator : AbstractValidator<Int32>
    {
        public DeleteVendor_Int32Validator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .Must(CheckIdIsNumber).WithMessage("Id Is Required");
        }

        public bool CheckIdIsNumber(int id)
        {
            if (id == 0 || id > Int32.MaxValue || id < 0)
                return false;
            return true;
        }
    }
}