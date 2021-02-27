using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Api.Validation.ModelValidator
{
    public class GetPaymentVoucherByID_Int32Validator:AbstractValidator<Int32>
    {
        public GetPaymentVoucherByID_Int32Validator()
        {
            RuleFor(x => x)
             .NotEmpty().WithMessage("Id Is Required")
             .Must(ValidId).WithMessage("Please Insert Valid Id");
        }

        private bool ValidId(int id)
        {
            if (id <= 0 || id > Int32.MaxValue)
                return false;
            return true;
        }
    }
}