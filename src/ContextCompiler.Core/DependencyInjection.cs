using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Guards;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Core.Common;
using ContextCompiler.Core.Guards;
using ContextCompiler.Core.Output;
using ContextCompiler.Core.Pipelines;
using ContextCompiler.Core.ReasoningIR;
using ContextCompiler.Core.Services;
using ContextCompiler.Core.Views;

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
                    .AddOutputServices()
                    .AddSingleton<ITagBuilder, TagBuilder>()
                    .AddTransient<ISourceRefBuilder, SourceRefBuilder>()
                    .AddSingleton<IReasoningIr, ReasoningIr>()
                    .AddSingleton<IGuardian, Guardian>()
                    .AddSingleton<IViewsProvider,ViewsProvider>();
            return services;
        }

    }
}
