using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules;

internal sealed class ModuleRestoreVersionBuilder : IModuleRestoreVersionBuilder
{
    internal sealed record ModuleRestoreVersion : IModuleRestoreVersion
    {
        public required string Raw { get; init; }
        public required string Min { get; init; }
        public required string Max { get; init; }

        public required IModuleRestoreVersion.BoundOperator MinBoundOperator { get; init; }
        public required IModuleRestoreVersion.BoundOperator MaxBoundOperator { get; init; }

    }

    private string? _raw;
    private string? _min;
    private string? _max;
    private IModuleRestoreVersion.BoundOperator? _minBoundOperator;
    private IModuleRestoreVersion.BoundOperator? _maxBoundOperator;

    public IModuleRestoreVersionBuilder InitNew()
    {
        _raw = null;
        _min = null;
        _max = null;
        _minBoundOperator = null;
        _maxBoundOperator = null;
        return this;
    }

    public IModuleRestoreVersionBuilder WithRaw(string raw)
    {
        _raw = raw;
        return this;
    }

    public IModuleRestoreVersionBuilder WithMin(string min)
    {
        _min = min;
        return this;
    }

    public IModuleRestoreVersionBuilder WithMinBoundOperator(IModuleRestoreVersion.BoundOperator boundOperator)
    {
        _minBoundOperator = boundOperator;
        return this;
    }

    public IModuleRestoreVersionBuilder WithMax(string max)
    {
        _max = max;
        return this;
    }

    public IModuleRestoreVersionBuilder WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator boundOperator)
    {
        _maxBoundOperator = boundOperator;
        return this;
    }

    public IModuleRestoreVersion Build()
    {
        return new ModuleRestoreVersion
        {
            Raw = _raw ?? throw new InvalidOperationException("Raw version must be set before building."),
            Min = _min ?? string.Empty,
            Max = _max ?? string.Empty,
            MinBoundOperator = _minBoundOperator ?? IModuleRestoreVersion.BoundOperator.Exactly,
            MaxBoundOperator = _maxBoundOperator ?? IModuleRestoreVersion.BoundOperator.Exactly
        };
    }
}
