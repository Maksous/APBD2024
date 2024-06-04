using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace APBD9.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request == null)
            {
                string path = httpContext.Request.Path;
                string queryString = httpContext.Request.QueryString.ToString();
                string method = httpContext.Request.Method.ToString();
                String bodyStr = "";


                using (StreamReader read = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = await read.ReadToEndAsync();
                }

                //logging into the file

                using (StreamReader fileStream = new StreamWriter(new FileStream(@"api.log", FileMode.Append)))
                {
                    string requestPath = httpContext.Request.Path;
                    string queryString = httpContext.Request.Query.ToString();
                    string method = httpContext.Request.Method.ToString();
                    DateTime now = DateTime.Now;
                    string outputString = "";
                    await fileStream.WriteAsync(outputString);


                }

            }
            await _next(httpContext);
        }
    }

    /*
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
    */
}
