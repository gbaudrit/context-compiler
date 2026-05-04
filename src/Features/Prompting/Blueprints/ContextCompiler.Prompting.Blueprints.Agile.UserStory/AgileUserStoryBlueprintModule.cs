using System.Reflection;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Prompting.Blueprints.Agile.UserStory;

public class AgileUserStoryBlueprintModule : IBlueprintModule
{
    public IEnumerable<Assembly> Discover()
    {
        return [
                typeof(ContextCompiler.Prompting.Modules.Personas.Analysts.Business.BusinessAnalystModule).Assembly
            ];
    }
}
