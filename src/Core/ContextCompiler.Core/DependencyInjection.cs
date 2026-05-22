using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Core.Common;
using ContextCompiler.Core.Compilation;
using ContextCompiler.Core.CompiledContext;
using ContextCompiler.Core.Configuration;
using ContextCompiler.Core.Files;
using ContextCompiler.Core.Guards;
using ContextCompiler.Core.Output;
using ContextCompiler.Core.Pipelines;
using ContextCompiler.Core.Sources;
using ContextCompiler.Core.Storage;
using ContextCompiler.Core.Tags;
using ContextCompiler.Core.Views;
using ContextCompiler.Core.Workspace;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddCompileCoreServices(this IServiceCollection services)
        {
            // Register core services here
            return services
                    .AddCompilation()
                    .AddSources()
                    .AddPipelines()
                    .AddCompiledContext()
                    .AddOutput()
                    .AddFiles()
                    .AddViews()
                    .AddTags()
                    .AddGuards()
                    .AddTransient<ISourceRefBuilder, SourceRefBuilder>()
                    .AddSingleton<ICtxcWorkingFolder, CtxcWorkingFolder>();
        }

        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            // Register core services here
            return services
                    .AddConfiguration()
                    .AddWorkspace()
                    .AddStorage()
                    .AddSingleton<ICtxcWorkingFolder, CtxcWorkingFolder>()
                    .AddTransient<IOutputArtifactReader, OutputArtifactReader>();
        }

    }
}
