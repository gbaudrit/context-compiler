using System.Text.Json;

using ContextCompiler.Modules.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Modules.Handlers;

internal sealed class ModulesPlanHandler(
    IModuleInstallPlanner moduleInstallPlanner,
    ILogger<ModulesPlanHandler> logger) : IModulesPlanHandler
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    public Task<int> HandleAsync(string cfgFile)
    {
        try
        {
            _ = cfgFile;

            ModuleInstallPlan plan = moduleInstallPlanner.CreatePlan();
            Console.WriteLine(JsonSerializer.Serialize(plan, JsonOptions));
            return Task.FromResult(0);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Internal error");
            return Task.FromResult(1);
        }
    }
}
