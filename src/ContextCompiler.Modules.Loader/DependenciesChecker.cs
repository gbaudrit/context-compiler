using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Modules.Loader;

internal sealed class DependenciesChecker : IDependenciesChecker
{
    private readonly IEnumerable<string> _builtinDependencies =
    [
        "System.Runtime",
        "System.Runtime.Caching",
        "System.Memory",
        "System.Text.Json",
        "Microsoft.Extensions.DependencyInjection.Abstractions",
        "Microsoft.Extensions.Configuration.Abstractions",
        "Microsoft.Extensions.Hosting.Abstractions",
        "Microsoft.Extensions.Logging.Abstractions",
        "Microsoft.Extensions.Primitives",
        "ContextCompiler.Abstractions",
        "ContextCompiler.Modules.Abstractions",
        "ModelContextProtocol",
        "ModelContextProtocol.Core"
    ];


    public bool IsRequired(string dependencyId, string dependencyVersion)
    {
        return _builtinDependencies.FirstOrDefault(d => d.Equals(dependencyId, StringComparison.OrdinalIgnoreCase)) == null;
    }

    public bool IsRequired(AssemblyName assemblyName)
    {
        string name = assemblyName.Name!;

        return !((name.StartsWith("System.", StringComparison.InvariantCultureIgnoreCase) && !name.Equals("System.Numerics.Tensors", StringComparison.Ordinal) && !name.Equals("System.IO.Packaging", StringComparison.Ordinal))
            || (name.StartsWith("Microsoft.", StringComparison.InvariantCultureIgnoreCase) && (!name.StartsWith("Microsoft.ML.", StringComparison.Ordinal)) && !name.Equals("Microsoft.Extensions.ObjectPool", StringComparison.Ordinal))
            || name == "netstandard"
            || name == "ContextCompiler.Abstractions"
            || name == "ContextCompiler.Modules.Abstractions");
    }

}
