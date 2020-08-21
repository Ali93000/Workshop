using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.PaymentVoucher.Request;

namespace Workshop.Api.Validation.ModelValidator
{
    public class CreatePaymentVoucher_PaymentVoucherReqValidator :AbstractValidator<PaymentVoucherReq>
    {
        public CreatePaymentVoucher_PaymentVoucherReqValidator()
        {
            RuleFor(x => x.PaimentTotal)
                .NotEmpty().WithMessage("{PropertyName Is Requird}");
        }
    }
}