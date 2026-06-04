namespace ContextCompiler.Modules.Abstractions
{
    public interface IDeclaredModuleBuilder
    {
        IDeclaredModule Build();
        IDeclaredModuleBuilder InitNew();
        IDeclaredModuleBuilder WithExtractPath(string extractPath);
        IDeclaredModuleBuilder WithPackageChecksum(string packageChecksum);
        IDeclaredModuleBuilder WithPackageId(IModuleRestoreId packageId);
        IDeclaredModuleBuilder WithPackageIdId(string packageIdId);
        IDeclaredModuleBuilder WithSource(IModuleRestoreSource source);
        IDeclaredModuleBuilder WithSourceId(string sourceId);
        IDeclaredModuleBuilder WithVersion(IModuleRestoreVersion version);
        IDeclaredModuleBuilder WithVersionMax(string versionMax);
        IDeclaredModuleBuilder WithVersionMaxBoundOperator(IModuleRestoreVersion.BoundOperator versionMaxBoundOperator);
        IDeclaredModuleBuilder WithVersionMin(string versionMin);
        IDeclaredModuleBuilder WithVersionMinBoundOperator(IModuleRestoreVersion.BoundOperator versionMinBoundOperator);
        IDeclaredModuleBuilder WithVersionRaw(string versionRaw);
    }
}
