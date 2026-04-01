using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Blueprints.DotNet.Api.Backend;

public class DotnetApiBackendBlueprintModule : IBlueprintModule
{
    public IEnumerable<Assembly> Discover()
    {
        return [
                typeof(Modules.Personas.Developers.DotNet.DotnetDeveloperModule).Assembly
            ];
    }
}
