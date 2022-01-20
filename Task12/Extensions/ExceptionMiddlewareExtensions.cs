using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Task12.Extensions {
    public static class ExceptionMiddlewareExtensions {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app) {
            app.UseExceptionHandler(appError => {
                appError.Run(async context => {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null) {
                        await context.Response.WriteAsync(new ErrorDetails() {
                            StatusCode = context.Response.StatusCode,
                            Message = $"Internal Server Error. {contextFeature.Error.Message}"
                        }.ToString());
                    }
                });
            });
        }

        private class ErrorDetails {
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public override string ToString() {
                return JsonSerializer.Serialize(this);
            }
        }
    }
}
