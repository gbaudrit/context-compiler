using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Prompting.Blueprints.React.Frontend;

public class ReactFrontendBlueprintModule : IBlueprintModule
{
    public IEnumerable<Assembly> Discover()
    {
        return [
                typeof(ContextCompiler.Prompting.Modules.Personas.Developers.React.ReactDeveloperModule).Assembly
            ];
    }
}
