using System.Diagnostics.CodeAnalysis;

namespace ContextCompiler.Modules.Abstractions
{

    public interface IModuleRestorePackageIdParser
    {
        bool TryParse(string packageId, [NotNullWhen(true)] out IModuleRestoreId? moduleRestoreId);
    }
}
