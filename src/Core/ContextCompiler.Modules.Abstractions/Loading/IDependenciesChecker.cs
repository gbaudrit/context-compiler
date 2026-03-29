using System.Reflection;

namespace ContextCompiler.Modules.Abstractions.Loading;

public interface IDependenciesChecker
{
    bool IsRequired(string dependencyId, string dependencyVersion);
    bool IsRequired(AssemblyName assemblyName);
}
