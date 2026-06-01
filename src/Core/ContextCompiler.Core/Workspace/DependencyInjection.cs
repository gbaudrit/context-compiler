using ContextCompiler.Abstractions.Workspace;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Workspace;

public static class DependencyInjection
{

    public static IServiceCollection AddWorkspace(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<IWorkspaceLoader, WorkspaceLoader>()
                        .AddSingleton(sp => (IWorkspaceAccessor)sp.GetRequiredService<IWorkspaceLoader>())
                       .AddSingleton<IWorkspaceViewsLoader, WorkspaceViewLoader>();
    }

}
