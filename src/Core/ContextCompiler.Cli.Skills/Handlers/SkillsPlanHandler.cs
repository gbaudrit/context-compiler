using System.Text.Json;

using ContextCompiler.Skills.Abstractions;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Cli.Skills.Handlers;

internal sealed class SkillsPlanHandler(
    ISkillInstallPlanner skillInstallPlanner,
    ILogger<SkillsPlanHandler> logger) : ISkillsPlanHandler
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    public Task<int> HandleAsync(string cfgFile)
    {
        try
        {
            _ = cfgFile;

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
