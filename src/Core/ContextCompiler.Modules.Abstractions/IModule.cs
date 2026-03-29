using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Modules.Abstractions;

public interface IModule
{
    static ModuleMetadata Meta(string id, GlobalPipelineModuleKinds kind, int priority = 0)
    {
        return new(id, kind, ModuleApiVersion.Current, priority);
    }

    ModuleMetadata Metadata { get; }


}
