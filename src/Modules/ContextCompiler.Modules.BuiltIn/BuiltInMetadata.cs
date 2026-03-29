using ContextCompiler.Abstractions.Versioning;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.BuiltIn;

public static class BuiltInMetadata
{
    public static ModuleMetadata Meta(string id, GlobalPipelineModuleKinds kind, int priority = 0)
    {
        return new(id, kind, ModuleApiVersion.Current, priority);
    }
}
