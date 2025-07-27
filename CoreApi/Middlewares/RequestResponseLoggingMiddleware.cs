using Serilog;
using System.Diagnostics;

namespace CoreApi.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();

            var requestBody = "";
            if (context.Request.ContentLength > 0)
            {
                context.Request.Body.Position = 0;
                using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
                requestBody = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
            }

            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            try
            {
                await _next(context);

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                await responseBody.CopyToAsync(originalBodyStream);

                var userId = context.User.FindFirst("UserID")?.Value ?? "Anonymous";
                var portalId = context.User.FindFirst("PortalID")?.Value ?? "Unknown";

                Log.ForContext("IpAddress", context.Connection.RemoteIpAddress?.ToString())
                   .ForContext("UserId", userId)
                   .ForContext("PortalId", portalId)
                   .ForContext("RequestBody", requestBody)
                   .ForContext("ResponseBody", responseBodyText)
                   .Information("Request completed {Method} {Path} {StatusCode}",
                        context.Request.Method,
                        context.Request.Path,
                        context.Response.StatusCode);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occurred processing request");
                throw;
            }
        }
    }
}
