using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Sources;

namespace ContextCompiler.Core.Sources;

internal sealed class Source : ISource
{
    public required ISourceConfigSectionReader ConfigSectionReader { get; init; }
    public required string RootPath { get; init; }
    public required string AddedBy { get; init; }
    public required ISourceConfigSection ConfigSection { get; init; }
    public required bool IsExternal { get; init; }
    public string OptionsKey => ConfigSection.OptionsKey;

    public string[] Includes => [.. ConfigSection.Includes, .. DynamicIncludes];
    public string[] Excludes => [.. ConfigSection.Excludes, .. DynamicExcludes];
    public string[] Tags => ConfigSection.Tags;

    public IReadOnlyList<string> DynamicIncludes { get; init; } = [];
    public IReadOnlyList<string> DynamicExcludes { get; init; } = [];

    public T Config<T>()
    {
        IResult<T> result = ConfigSectionReader.TryRead<T>(ConfigSection, OptionsKey);
        return result is IFailureResult<T> failure
            ? throw new InvalidOperationException($"Failed to read source configuration for source with root path '{RootPath}' and options key '{OptionsKey}'. Reason: {failure.Message}")
            : ((ISuccessResult<T>)result).Value;
    }

}
