using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Api.Validation.ModelValidator
{
    public class DeleteCustomer_Int32Validator : AbstractValidator<Int32>
    {
        public DeleteCustomer_Int32Validator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .Must(CheckIdIsNumber).WithMessage("Id Is Required");
        }

        public bool CheckIdIsNumber(int id)
        {
            if (id == 0 || id > Int32.MaxValue || id < Int32.MinValue)
                return false;
            return true;
        }
    }
}