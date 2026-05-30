namespace ContextCompiler.Abstractions.DependencyInjection;

public interface IContextCompilerStorageBuilder
{

    IContextCompilerStorageBuilder UpdateStoreName(string storeKey, string newName);

}
