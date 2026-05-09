using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Versioning;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Modules.Abstractions;

public interface IViewModule : IModule
{
    static ViewModuleMetadata Meta(string id, ViewModuleKinds kinds, int priority = 0)
    {
        return new(id, kinds, ModuleApiVersion.Current, priority);
    }

    Task<IReadOnlyList<IViewResult>> Run(ViewContext ctx, CancellationToken ct);

    ViewModuleMetadata Metadata { get; }

    string ViewId { get; }
}

public sealed record ViewContext(
    IViewsConfigSection Config,
    ICompiledContext CompiledContext,
    IReadOnlyDictionary<string, object>? Inputs = null,
    bool EmitJson = true,
    bool EmitMarkdown = true
);



