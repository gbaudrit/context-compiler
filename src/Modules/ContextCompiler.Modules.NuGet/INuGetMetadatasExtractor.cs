namespace ContextCompiler.Modules.NuGet;

public interface INuGetMetadatasExtractor
{
    NuGetPackageMetadata ExtractMetadatas(string nupkgPath);
}
