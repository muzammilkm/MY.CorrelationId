using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MY.CorrelationId;
using Serilog.Context;
using System;
using System.Threading.Tasks;

namespace My.CorrelationId.AspNetCore.Serilog
{
    public class CorrelationMiddleware
    {
        private readonly RequestDelegate _next;

        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var correlationIdProvider = context.RequestServices.GetRequiredService<ICorrelationIdProvider>();

            LogContext.PushProperty("US-CorrelationId", correlationIdProvider.GetCorrelationId());

            await _next(context);
        }
    }
}
