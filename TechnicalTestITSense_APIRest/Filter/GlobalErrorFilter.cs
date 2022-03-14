using Core.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Net;

namespace TechnicalTestITSense_APIRest.Filter
{
    public static class GlobalErrorFilter
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    _ = new HttpException();
                    HttpException error;

                    if (contextFeature.Error is HttpException)
                    {
                        error = contextFeature.Error as HttpException;
                         context.Response.StatusCode = (int)error.StatusCode;
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = (int)error.StatusCode,
                            Message =  error.Messages
                        }.ToString());
                    }
                    else
                    {
                        if (contextFeature != null)
                        {
                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = new List<string> { "Internal Server Error." }
                            }.ToString());
                        }
                    }
                });
            });
        }
    }
}
