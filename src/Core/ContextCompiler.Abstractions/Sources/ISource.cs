using ContextCompiler.Abstractions.Configuration.Sections;

namespace ContextCompiler.Abstractions.Sources;

public interface ISource
{

    string RootPath { get; }
    string OptionsKey { get; }
    string[] Includes { get; }
    string[] Excludes { get; }
    string[] Tags { get; }
    string AddedBy { get; init; }
    IReadOnlyList<string> DynamicIncludes { get; init; }
    IReadOnlyList<string> DynamicExcludes { get; init; }
    ISourceConfigSection ConfigSection { get; init; }
    ISourceConfigSectionReader ConfigSectionReader { get; init; }
    bool IsExternal { get; init; }

    T Config<T>();
}
