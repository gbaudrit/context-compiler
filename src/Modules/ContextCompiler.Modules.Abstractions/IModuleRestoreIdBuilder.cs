namespace ContextCompiler.Modules.Abstractions;

public interface IModuleRestoreIdBuilder
{
    IModuleRestoreId Build();
    IModuleRestoreIdBuilder InitNew();
    IModuleRestoreIdBuilder WithChecksum(string checksum);
    IModuleRestoreIdBuilder WithId(string id);
    IModuleRestoreIdBuilder WithSource(IModuleRestoreSource source);
}
