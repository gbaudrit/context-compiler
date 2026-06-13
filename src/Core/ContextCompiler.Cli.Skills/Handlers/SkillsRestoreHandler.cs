using ContextCompiler.Abstractions.DependencyInjection;
using ContextCompiler.Skills.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Skills.Handlers;

internal sealed class SkillsRestoreHandler(
    IContextCompilerAutonomousServiceProviderCreator contextCompilerAutonomousServiceProviderCreator,
    ILogger<SkillsRestoreHandler> logger) : ISkillsRestoreHandler
{
    public async Task<int> HandleAsync(CancellationToken cancellationToken)
    {
        try
        {
            SkillsRestoreResult result = await RestoreSkillsAsync(cancellationToken);
            Console.WriteLine($"Skills lock file written with {result.LockFile.Skills.Count} skill(s).");
            return 0;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return 1;
        }
    }

    public async Task<SkillsRestoreResult> RestoreSkillsAsync(CancellationToken cancellationToken)
    {
        IServiceProvider restoreProvider = await contextCompilerAutonomousServiceProviderCreator.WithModulesLoaded(cancellationToken);
        ISkillsRestorer restorer = restoreProvider.GetRequiredService<ISkillsRestorer>();
        return await restorer.RestoreAsync(cancellationToken);
    }
}
