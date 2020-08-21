using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workshop.Api.Validation.ModelValidator
{
    public class GetServicesById_int32Validator : AbstractValidator<Int32>
    {
        public GetServicesById_int32Validator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("{PropertyName} Is Requird")
                .Must(idValid).WithMessage("{PropertyName} Please Insert Valid Id");
        }

        private bool idValid(int id)
        {
            if (id <= 0 || id > Int32.MaxValue)
            return false;
            return true;
        }
    }
}