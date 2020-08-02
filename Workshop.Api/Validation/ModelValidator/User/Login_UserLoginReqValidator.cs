using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workshop.Entities.ApiModels.User.Request;

namespace Workshop.Api.Validation.ModelValidator
{
    public class Login_UserLoginReqValidator : AbstractValidator<UserLoginReq>
    {
        public Login_UserLoginReqValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("{PropertyName Is Required!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName Is Required!");
        }
    }
}