using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.Item;

namespace Workshop.Api.Validation.ModelValidator
{
    public class UpdateItem_ItemReqValidator : AbstractValidator<ItemReq>
    {
        public UpdateItem_ItemReqValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThanOrEqualTo(0).WithMessage("Please Insert Valid Id")
              .NotEmpty().WithMessage("Id Is Required to Complete Update Process");
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.ItemCode)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.ItemDescAr)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.ItemDescEn)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.ItemPurchPrice)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.LowestSellingPrice)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.MadeInCountry)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.PurchDate)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.SellingPrice)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.VendorId)
                .NotEmpty().WithMessage("{PropertyName} Is Required");
        }
    }
}