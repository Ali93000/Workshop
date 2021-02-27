using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.Vendor.Request;

namespace Workshop.Api.Validation.ModelValidator
{
    public class CreateVendor_VendorReqValidator : AbstractValidator<VendorReq>
    {
        public CreateVendor_VendorReqValidator()
        {
            RuleFor(x => x.Mobile1)
                .NotEmpty().WithMessage("{PropertyName} Is Requierd");
            RuleFor(x => x.Mobile2)
                .NotEmpty().WithMessage("{PropertyName} Is Requierd");
            RuleFor(x => x.ResponsibleName)
                .NotEmpty().WithMessage("{PropertyName} Is Requierd");
        }
        // Validation NO REPEAT Mobil
        //private bool NoRepeatMobil(string arg)
        //{
            
        //}
    }
}