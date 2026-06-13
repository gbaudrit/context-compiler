namespace ContextCompiler.Modules.Abstractions;

public interface IModuleVersionOverrideResolver
{
    string ResolveVersion(string packageKey, string packageId, string sourceId, string requestedVersion);
}
