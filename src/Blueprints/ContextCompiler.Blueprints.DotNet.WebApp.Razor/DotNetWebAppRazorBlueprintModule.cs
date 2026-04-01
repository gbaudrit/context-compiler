using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Blueprints.DotNet.WebApp.Razor;

public class DotNetWebAppRazorBlueprintModule : IBlueprintModule
{
    public IEnumerable<Assembly> Discover()
    {
        return [
            typeof(Packs.Starter.Standard.StarterStandardPack).Assembly,
                typeof(Modules.Personas.Developers.DotNet.DotnetDeveloperModule).Assembly
            ];
    }
}
