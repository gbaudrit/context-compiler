using System.Diagnostics.CodeAnalysis;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IModuleRestoreVersionParser
    {

        bool TryParse(string version, [NotNullWhen(true)] out IModuleRestoreVersion? moduleRestoreVersion);

    }
}
