using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Blueprints.Agile.UserStory;

public class AgileUserStoryBlueprintModule : IBlueprintModule
{
    public IEnumerable<Assembly> Discover()
    {
        return [
                typeof(Modules.Personas.Analysts.Business.BusinessAnalystModule).Assembly
            ];
    }
}
