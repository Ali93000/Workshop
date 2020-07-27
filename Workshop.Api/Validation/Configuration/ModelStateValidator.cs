using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using Workshop.Entities.ApiModels;

namespace Workshop.Api.Validation.Configuration
{
    public class ModelStateValidator : IModelStateValidator
    {
        public GenericResponse ValidateModel(object model, [CallerMemberName] string callerMethodName = "")
        {
            List<string> errorsList = new List<string>();

            if (model != null)
            {
                string className = $"Workshop.Api.Validation.ModelValidator.{callerMethodName}_{model.GetType().Name}Validator";
                Type validatorType = Type.GetType(className);
                var validatorInstance = (IValidator)Activator.CreateInstance(validatorType);

                ValidationResult validationResult = validatorInstance.Validate(model);

                if (validationResult.IsValid)
                {
                    return null;
                }

                foreach (var error in validationResult.Errors)
                {
                    errorsList.Add(error.ErrorMessage);
                }
            }
            else
            {
                errorsList.Add("Request Object Is Required");
            }

            return new GenericResponse
            {
                IsSuccessful = false,
                ResponseCode = (HttpStatusCode)422,
                ResponseMessages = errorsList
            };
        }
    }
}