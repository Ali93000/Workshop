using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Api.Validation.ModelValidator
{
    public class GetEmployeeById_Int32Validator : AbstractValidator<Int32>
    {
        public GetEmployeeById_Int32Validator()
        {
            RuleFor(x => x)
                .Must(BeValidNumber).WithMessage("Id Is Required");
        }

        public bool BeValidNumber(int id)
        {
            if (id == 0 || id > Int32.MaxValue || id < 0)
                return false;
            return true;
        }
    }
}