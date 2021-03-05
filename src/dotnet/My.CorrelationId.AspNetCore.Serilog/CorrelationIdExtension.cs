using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MY.CorrelationId;

namespace My.CorrelationId.AspNetCore.Serilog
{
    public static class CorrelationIdExtension
    {
        public static IServiceCollection AddCorrelationId(this IServiceCollection services)
        {
            return services.AddScoped<ICorrelationIdProvider, CorrelationIdProvider>();
        }

        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app, string propertyName = "X-CorrelationId")
        {
            return app.UseMiddleware<CorrelationMiddleware>(propertyName);
        }
    }
}
