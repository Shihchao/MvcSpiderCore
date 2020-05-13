using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest
{
    public class RequestResponseExtension
    {

        public async Task Invoke(HttpContext context)
        {
            HttpRequest request = context.Request;
            
            // 获取请求body内容
            if (request.Method.ToLower().Equals("option"))
            {
                context.Response.OnCompleted(() =>
                {
                    context.Response.StatusCode = 200;
                    return Task.CompletedTask;
                });
            }
            
            if (String.IsNullOrEmpty(request.Headers["token"]))
            {
                context.Response.OnCompleted(() =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                });
            }
           

        }
    }

    /// <summary>
    /// 扩展中间件
    /// </summary>
    public static class RequestResponseExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestResponseExtension>();
        }
    }
}
}
