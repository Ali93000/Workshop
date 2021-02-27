using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.CashReceipt.Request;

namespace Workshop.Api.Validation.ModelValidator
{
    public class UpdateCachReceipt_ReceiptVoucherReqValidator : AbstractValidator<ReceiptVoucherReq>
    {
        public UpdateCachReceipt_ReceiptVoucherReqValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Please Insert Valid ID")
                .NotEmpty().WithMessage("ID is requaird");
        }
    }
}