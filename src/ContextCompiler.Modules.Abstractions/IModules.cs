namespace ContextCompiler.Modules.Abstractions
{
    public interface IModules
    {
        Task Run(CancellationToken cancellationToken);
    }


    public interface IModules<TModules> : IModules where TModules : IModule
    {


    }
}
