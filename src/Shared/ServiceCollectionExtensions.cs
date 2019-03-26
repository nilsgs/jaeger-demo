using Jaeger;
using Jaeger.Samplers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OpenTracing;
using OpenTracing.Contrib.NetCore.CoreFx;
using OpenTracing.Util;

namespace Shared
{
    public static class ServiceCollectionExtensions
    {
        public static void AddJaeger(this IServiceCollection services)
        {
            // Open Tracing instrumentation
            services.AddOpenTracing();

            services.AddSingleton<ITracer>(serviceProvider =>
            {
                var serviceName = serviceProvider.GetRequiredService<IHostingEnvironment>().ApplicationName;

                // This will log to a default localhost installation of Jaeger.
                var tracer = new Tracer.Builder(serviceName)
                    .WithSampler(new ConstSampler(true))
                    .Build();

                // Allows code that can't use DI to also access the tracer.
                GlobalTracer.Register(tracer);

                return tracer;
            });

            services.Configure<HttpHandlerDiagnosticOptions>(opt =>
            {
                opt.IgnorePatterns.Add(request => request.RequestUri.ToString().Contains("api/traces"));
            });
        }
    }
}
