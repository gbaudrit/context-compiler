using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Prompting.Blueprints.DotNet.Api.Backend;

public class DotnetApiBackendBlueprintModule : IBlueprintModule
{
    public IEnumerable<Assembly> Discover()
    {
        return [
                typeof(ContextCompiler.Prompting.Modules.Personas.Developers.DotNet.DotnetDeveloperModule).Assembly
            ];
    }
}
