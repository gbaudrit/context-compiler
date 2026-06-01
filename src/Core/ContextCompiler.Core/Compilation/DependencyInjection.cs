using ContextCompiler.Abstractions;
using ContextCompiler.Abstractions.Compilation;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Compilation;

public static class DependencyInjection
{

    public static IServiceCollection AddCompilation(this IServiceCollection services)
    {
        // Register core services here
        return services.AddTransient<ISourceFilesDefinitionBuilder, SourceFilesDefinitionBuilder>()
                       .AddSingleton<ICompiledWorkingFolder, CompiledWorkingFolder>()
                       .AddSingleton<ICompilationContext, CompilationContext>();
    }
}
