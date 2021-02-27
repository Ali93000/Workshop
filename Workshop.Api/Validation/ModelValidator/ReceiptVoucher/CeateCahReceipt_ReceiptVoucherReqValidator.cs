using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.CashReceipt.Request;

namespace Workshop.Api.Validation.ModelValidator
{
    public class CeateCahReceipt_ReceiptVoucherReqValidator:AbstractValidator<ReceiptVoucherReq>
    {
        public CeateCahReceipt_ReceiptVoucherReqValidator()
        {
            RuleFor(x => x.Amount_Paid)
                .NotEmpty().WithMessage("{PropertyName is Requaird}");
        }
    }
}