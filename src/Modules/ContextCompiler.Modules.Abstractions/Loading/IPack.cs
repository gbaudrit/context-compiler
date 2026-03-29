using System.Reflection;

namespace ContextCompiler.Modules.Abstractions.Loading;

public interface IPack
{

    IEnumerable<Assembly> Discover();

}
