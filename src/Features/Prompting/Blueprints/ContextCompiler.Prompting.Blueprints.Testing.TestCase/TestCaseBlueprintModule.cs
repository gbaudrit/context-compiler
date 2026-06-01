using System.Reflection;

namespace ContextCompiler.Prompting.Blueprints.Testing.TestCase;

public class TestCaseBlueprintModule
{
    public static IEnumerable<Assembly> Discover()
    {
        return [
                typeof(ContextCompiler.Prompting.Modules.Personas.Testers.Analyst.TestAnalystModule).Assembly
            ];
    }
}
