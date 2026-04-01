using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Blueprints.React.Frontend;

public class ReactFrontendBlueprintModule : IBlueprintModule
{
    public IEnumerable<Assembly> Discover()
    {
        return [
                typeof(Modules.Personas.Developers.React.ReactDeveloperModule).Assembly
            ];
    }
}
