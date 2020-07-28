using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.Customer;

namespace Workshop.Api.Validation.ModelValidator
{
    public class CreateCustomer_CustomerReqValidator : AbstractValidator<CustomerReq>
    {
        public CreateCustomer_CustomerReqValidator()
        {
            RuleFor(x => x.CustomerAddress)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.CustomerCode)
                .NotEmpty().WithMessage("CustomerCode Is Required");
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("CustomerName Is Required");
            RuleFor(x => x.Mobil1)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.Mobil2)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
        }
    }
}