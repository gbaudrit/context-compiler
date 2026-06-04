namespace ContextCompiler.Modules.Abstractions;

public sealed record ModuleInstallPlan(IReadOnlyList<ModuleInstallPlanItem> Items);

public sealed record ModuleInstallPlanItem(
    string Id,
    string RequestedVersion,
    ModuleInstallPlanSource Source,
    IReadOnlyList<string> RequestedBy);

public enum ModuleInstallPlanSource
{
    Configuration,
    RunModules
}

public interface IModuleInstallPlanner
{
    ModuleInstallPlan CreatePlan(IReadOnlyDictionary<string, string>? runModules = null);
}
