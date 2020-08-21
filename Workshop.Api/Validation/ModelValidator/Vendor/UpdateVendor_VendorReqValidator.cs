using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.Vendor.Request;

namespace Workshop.Api.Validation.ModelValidator
{
    public class UpdateVendor_VendorReqValidator : AbstractValidator<VendorReq>
    {
        public UpdateVendor_VendorReqValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0).WithMessage("Please Insert Valid Id")
              .NotEmpty().WithMessage("Id Is Required to Complete Update Process");
            RuleFor(x => x.Mobile1)
              .NotEmpty().WithMessage("{PropertyName} Is Requierd");
            RuleFor(x => x.Mobile2)
                .NotEmpty().WithMessage("{PropertyName} Is Requierd");
            RuleFor(x => x.ResponsibleName)
                .NotEmpty().WithMessage("{PropertyName} Is Requierd");
        }
    }
}