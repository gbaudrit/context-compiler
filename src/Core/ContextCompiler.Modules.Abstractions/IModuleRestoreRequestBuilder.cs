namespace ContextCompiler.Modules.Abstractions
{
    public interface IModuleRestoreRequestBuilder
    {
        IModuleRestoreRequest Build();
        IModuleRestoreRequestBuilder InitNew();
        IModuleRestoreRequestBuilder WithExtractPath(string extractPath);
        IModuleRestoreRequestBuilder WithPackageChecksum(string packageChecksum);
        IModuleRestoreRequestBuilder WithPackageId(IModuleRestoreId packageId);
        IModuleRestoreRequestBuilder WithPackageIdId(string packageIdId);
        IModuleRestoreRequestBuilder WithSource(IModuleRestoreSource source);
        IModuleRestoreRequestBuilder WithSourceId(string sourceId);
        IModuleRestoreRequestBuilder WithVersion(IModuleRestoreVersion version);
        IModuleRestoreRequestBuilder WithVersionMax(string versionMax);
        IModuleRestoreRequestBuilder WithVersionMaxBoundOperator(IModuleRestoreVersion.BoundOperator versionMaxBoundOperator);
        IModuleRestoreRequestBuilder WithVersionMin(string versionMin);
        IModuleRestoreRequestBuilder WithVersionMinBoundOperator(IModuleRestoreVersion.BoundOperator versionMinBoundOperator);
        IModuleRestoreRequestBuilder WithVersionRaw(string versionRaw);
    }
}
