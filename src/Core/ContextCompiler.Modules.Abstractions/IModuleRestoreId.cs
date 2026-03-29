namespace ContextCompiler.Modules.Abstractions
{

    public interface IModuleRestoreId
    {
        string Id { get; }
        IModuleRestoreSource Source { get; }

        string Checksum { get; }
    }
}
