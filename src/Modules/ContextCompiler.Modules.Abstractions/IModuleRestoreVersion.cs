namespace ContextCompiler.Modules.Abstractions
{

    public interface IModuleRestoreVersion
    {
        enum BoundOperator
        {
            Exactly,
            GreaterThan,
            GreaterThanOrEqual,
            LessThan,
            LessThanOrEqual,
            Unbounded
        }
        string Raw { get; init; }
        string Max { get; init; }
        string Min { get; init; }
        BoundOperator MinBoundOperator { get; init; }
        BoundOperator MaxBoundOperator { get; init; }
    }
}
