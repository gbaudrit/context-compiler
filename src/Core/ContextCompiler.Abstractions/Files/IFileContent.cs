namespace ContextCompiler.Abstractions.Files
{
    public interface IFileContent : IDisposable
    {

        Stream NextPart();

    }
}
