using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.ApiModels;

namespace Workshop.Api.Validation.Configuration
{
    public interface IModelStateValidator
    {
        GenericResponse ValidateModel(object model, [CallerMemberName] string callerMethodName = "");
    }
}
