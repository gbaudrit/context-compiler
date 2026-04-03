using System.Reflection;

namespace ContextCompiler.Blueprints.Testing.TestCase;

public class TestCaseBlueprintModule
{
    public static IEnumerable<Assembly> Discover()
    {
        return [
                typeof(Modules.Personas.Testers.Analyst.TestAnalystModule).Assembly
            ];
    }
}
