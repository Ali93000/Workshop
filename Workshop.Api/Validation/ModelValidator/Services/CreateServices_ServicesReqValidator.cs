using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.Services.Request;

namespace Workshop.Api.Validation.ModelValidator
{
    public class CreateServices_ServicesReqValidator:AbstractValidator<ServicesReq>
    {
        public CreateServices_ServicesReqValidator()
        {
            RuleFor(x => x.DescriptionServicesA__DescriptionServicesA__DescriptionServicesA).NotEmpty().WithMessage("{Property Name is Requaird}");
        }
    }
}