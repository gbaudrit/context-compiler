using System.Reflection;

namespace ContextCompiler.Modules.Abstractions.Loading;

public interface IPackModule
{

    IEnumerable<Assembly> Discover();

}
