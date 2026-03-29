namespace ContextCompiler.Modules.Abstractions;

public interface IModuleRestoreSourceBuilder
{
    IModuleRestoreSource Build();
    IModuleRestoreSourceBuilder InitNew();
    IModuleRestoreSourceBuilder WithId(string id);
}
