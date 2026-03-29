namespace ContextCompiler.Modules.Abstractions
{
    public interface IModuleRestoreVersionBuilder
    {
        IModuleRestoreVersion Build();
        IModuleRestoreVersionBuilder InitNew();
        IModuleRestoreVersionBuilder WithMax(string versionMax);
        IModuleRestoreVersionBuilder WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator versionMaxBoundOperator);
        IModuleRestoreVersionBuilder WithMin(string versionMin);
        IModuleRestoreVersionBuilder WithMinBoundOperator(IModuleRestoreVersion.BoundOperator versionMinBoundOperator);
        IModuleRestoreVersionBuilder WithRaw(string versionRaw);
    }
}
