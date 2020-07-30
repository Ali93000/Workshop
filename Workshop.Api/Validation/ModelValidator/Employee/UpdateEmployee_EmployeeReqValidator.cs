using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.Employee;

namespace Workshop.Api.Validation.ModelValidator
{
    public class UpdateEmployee_EmployeeReqValidator : AbstractValidator<EmployeeReq>
    {
        public UpdateEmployee_EmployeeReqValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThanOrEqualTo(0).WithMessage("Please Insert Valid Id")
            .NotEmpty().WithMessage("Id Is Required to Complete Update Process");

            RuleFor(x => x.EmpCode)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.EmpName)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.EmpSpecialist)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.Mobile1)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.Mobile2)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
        }

    }
}