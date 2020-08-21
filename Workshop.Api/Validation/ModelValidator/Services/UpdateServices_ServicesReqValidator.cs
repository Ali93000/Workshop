using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.Services.Request;

namespace Workshop.Api.Validation.ModelValidator
{
    public class UpdateServices_ServicesReqValidator:AbstractValidator<ServicesReq>
    {
        public UpdateServices_ServicesReqValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Please Insert Valid Id")
                .NotEmpty().WithMessage("Id Is Required to Complete Update Process");
        }
    }
}