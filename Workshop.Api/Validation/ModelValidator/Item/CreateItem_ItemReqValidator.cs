using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.Item;

namespace Workshop.Api.Validation.ModelValidator
{
    public class CreateItem_ItemReqValidator : AbstractValidator<ItemReq>
    {
        public CreateItem_ItemReqValidator()
        {
            RuleFor(x => x.CategoryId)
             .NotEmpty().WithMessage("{PropertyName} Is Required");
            RuleFor(x => x.ItemCode)
                .NotEmpty().WithMessage("CustomerCode Is Required");
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