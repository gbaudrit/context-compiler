using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Models;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Core.Commands;
using ContextCompiler.Core.Common;
using ContextCompiler.Core.Configuration;
using ContextCompiler.Core.Files;
using ContextCompiler.Core.Framing;
using ContextCompiler.Core.Guards;
using ContextCompiler.Core.Output;
using ContextCompiler.Core.Personas;
using ContextCompiler.Core.Pipelines;
using ContextCompiler.Core.ReasoningIR;
using ContextCompiler.Core.Tags;
using ContextCompiler.Core.Views;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddCompileCoreServices(this IServiceCollection services)
        {
            // Register core services here
            return services
                    .AddPipelines()
                    .AddReasoningIR()
                    .AddPersonas()
                    .AddOutput()
                    .AddFiles()
                    .AddViews()
                    .AddTags()
                    .AddGuards()
                    .AddFraming()
                    .AddCommands()
                    .AddSingleton<IPrompt, Prompt>()
                    .AddTransient<ISourceRefBuilder, SourceRefBuilder>()
                    .AddSingleton<ICtxcWorkingFolder, CtxcWorkingFolder>();
        }

        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            // Register core services here
            return services
                    .AddConfiguration()
                    .AddSingleton<ICtxcWorkingFolder, CtxcWorkingFolder>();
        }

    }
}
