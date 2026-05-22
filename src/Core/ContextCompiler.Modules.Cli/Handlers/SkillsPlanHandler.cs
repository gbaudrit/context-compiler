using System.Text.Json;

using ContextCompiler.Modules.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions.Skills;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Modules.Cli.Handlers;

internal sealed class SkillsPlanHandler(
    IModulesLoadConfigLocator modulesLoadConfigLocator,
    IModulesLoadConfigProvider modulesLoadConfigProvider,
    ISkillsLoadConfigProvider skillsLoadConfigProvider,
    ISkillInstallPlanner skillInstallPlanner,
    ILogger<SkillsPlanHandler> logger) : ISkillsPlanHandler
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    public Task<int> HandleAsync(string cfgFile)
    {
        try
        {
            string? configPath = modulesLoadConfigLocator.Locate(cfgFile, "", "");
            _ = modulesLoadConfigProvider.GetConfigOrDefault(configPath);
            _ = skillsLoadConfigProvider.GetConfigOrDefault(configPath);

            SkillInstallPlan plan = skillInstallPlanner.CreatePlan();
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
