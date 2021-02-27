using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.PaymentVoucher.Request;

namespace Workshop.Api.Validation.ModelValidator
{
    public class UpdatePaymentVoucher_PaymentVoucherReqValidator:AbstractValidator<PaymentVoucherReq>
    {
        public UpdatePaymentVoucher_PaymentVoucherReqValidator()
        {
            RuleFor(x => x.PaimentTotal)
                .NotEmpty().WithMessage("{PropertyName Is Requaird}");
        }
    }
}