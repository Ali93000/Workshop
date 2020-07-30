using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Api.Validation.ModelValidator
{
    public class DeleteEmployee_Int32Validator : AbstractValidator<Int32>
    {
        public DeleteEmployee_Int32Validator()
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