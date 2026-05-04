using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Prompting.Blueprints.DotNet.WebApp.Razor;

public class DotNetWebAppRazorBlueprintModule : IBlueprintModule
{
    public IEnumerable<Assembly> Discover()
    {
        return [
            typeof(ContextCompiler.Packs.Starter.Standard.StarterStandardPack).Assembly,
                typeof(ContextCompiler.Prompting.Modules.Personas.Developers.DotNet.DotnetDeveloperModule).Assembly
            ];
    }
}
