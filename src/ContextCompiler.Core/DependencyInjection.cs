using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Core.Common;
using ContextCompiler.Core.Pipelines;
using ContextCompiler.Core.ReasoningIR;
using ContextCompiler.Core.Services;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            // Register core services here
            services.AddPipelinesServices()
                    .AddReasoningIRServices()
                    .AddSingleton<ITagBuilder, TagBuilder>()
                    .AddTransient<ISourceRefBuilder,SourceRefBuilder>();
            return services;
        }

    }
}
