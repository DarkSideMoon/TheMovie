using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TheMovie.Model.ViewModel;

namespace TheMovie.Api.Filters
{
    /// <summary>
    /// Custom exception filter attribute for controllers
    /// </summary>
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        /// <summary>
        /// Handle error
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            var error = new ErrorViewModel()
            {
                Error = context.Exception.Message,
                StackTrace = context.Exception.StackTrace,
                ActionName = context.ActionDescriptor.DisplayName
            };

            context.Result = new ContentResult
            {
                Content = error.BuildJson(),
                ContentType = "application/json",
                StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError,
            };
            context.ExceptionHandled = true;
        }
    }
}
