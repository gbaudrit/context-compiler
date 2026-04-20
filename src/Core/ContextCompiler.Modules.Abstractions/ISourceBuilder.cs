
namespace ContextCompiler.Modules.Abstractions
{
    public interface ISourceBuilder
    {
        IModuleSource Build();
        ISourceBuilder InitNew();
        ISourceBuilder WithId(string id);
        ISourceBuilder WithProvider(string provider);
        ISourceBuilder WithUrl(Uri url);
    }
}
