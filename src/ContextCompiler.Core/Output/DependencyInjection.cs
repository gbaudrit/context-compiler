using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Core.Common;
using ContextCompiler.Core.Pipelines;
using ContextCompiler.Core.ReasoningIR;
using ContextCompiler.Core.Services;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Output
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddOutputServices(this IServiceCollection services)
        {
            // Register core services here
            services.AddTransient<IOutputArtifactWriter, OutputArtifactWriter>()
                .AddTransient<IOutputJsonArtifactWriter, OutputJsonArtifactWriter>()
                .AddSingleton<IOutputContext, OutputContext>();
            return services;
        }

    }
}
