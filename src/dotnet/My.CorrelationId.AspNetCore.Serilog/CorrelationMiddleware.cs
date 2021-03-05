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
        private readonly string _propertyName;

        public CorrelationMiddleware(RequestDelegate next, string propertyName)
        {
            _next = next;
            _propertyName = propertyName;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var correlationIdProvider = context.RequestServices.GetRequiredService<ICorrelationIdProvider>();

            LogContext.PushProperty(_propertyName, correlationIdProvider.GetCorrelationId());

            await _next(context);
        }
    }
}
