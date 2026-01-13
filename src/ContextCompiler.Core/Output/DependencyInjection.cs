using ContextCompiler.Abstractions.Output;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Output
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddOutput(this IServiceCollection services)
        {
            // Register core services here
            services.AddTransient<IOutputArtifactWriter, OutputArtifactWriter>()
                .AddTransient<IOutputJsonArtifactWriter, OutputJsonArtifactWriter>()
                .AddSingleton<IOutputContext, OutputContext>();
            return services;
        }

    }
}
