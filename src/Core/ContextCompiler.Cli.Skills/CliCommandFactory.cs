using System.CommandLine;

using ContextCompiler.Cli.Skills.Handlers;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Cli.Skills;

public static class CliCommandFactory
{
    /// <summary>
    /// Builds the <c>skills</c> top-level command tree contributed to the unified ctxc CLI.
    /// </summary>
    public static Command BuildSkillsCommand(IServiceProvider sp)
    {
        Command skills = new("skills", "Plan and restore declarative skills.");
        Option<string> configOpt = new("--config", () => ".", "Path to ctxc.config.json");

        Command skillsPlan = new("plan", "Create a deterministic skills installation plan.") { configOpt };
        skillsPlan.SetHandler(async cfgFile =>
        {
            ISkillsPlanHandler handler = sp.GetRequiredService<ISkillsPlanHandler>();
            Environment.ExitCode = await handler.HandleAsync(cfgFile);
        }, configOpt);

        Command skillsRestore = new("restore", "Restore declarative skills into the skills cache using already-restored modules.") { configOpt };
        skillsRestore.SetHandler(async cfgFile =>
        {
            ISkillsRestoreHandler handler = sp.GetRequiredService<ISkillsRestoreHandler>();
            Environment.ExitCode = await handler.HandleAsync(cfgFile);
        }, configOpt);

        skills.AddCommand(skillsPlan);
        skills.AddCommand(skillsRestore);
        return skills;
    }
}
