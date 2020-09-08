using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using TheMovie.Model.Common;
using TheMovie.Model.Exceptions;

namespace TheMovie.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private static readonly string InternalServerErrorMessage = "Internal Server Error";
        private static readonly string MovieClientErrorMessage = "Movie Client Error";

        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (MovieClientException movieClientException)
            {
                await HandleExceptionAsync(httpContext, movieClientException,
                    MovieClientErrorMessage, 
                    StatusCodes.Status500InternalServerError)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, InternalServerErrorMessage, 
                    StatusCodes.Status500InternalServerError)
                    .ConfigureAwait(false);
            }
        }

        protected static Task HandleExceptionAsync(HttpContext context, Exception exception, string message, int statusCode)
        {
            Log.Error(exception, message);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            var errorResponse = CreateErrorResponse(context, message);
            var errorResponseJson = JsonConvert.SerializeObject(errorResponse,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            return context.Response.WriteAsync(errorResponseJson);
        }

        protected static ErrorResponse CreateErrorResponse(HttpContext context, string message)
        {
            return new ErrorResponse(context.Response.StatusCode.ToString(), message);
        }
    }
}
