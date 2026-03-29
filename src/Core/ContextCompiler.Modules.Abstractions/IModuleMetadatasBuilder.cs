namespace ContextCompiler.Modules.Abstractions;

public interface IModuleMetadatasBuilder
{
    IModuleMetadatasBuilder InitNew();
    IModuleMetadatasBuilder InitNewFrom(IModuleMetadatas moduleMetadatas);
    IModuleMetadatasBuilder WithAuthors(params string[] authors);
    IModuleMetadatasBuilder WithRepositoryUrl(Uri? repositoryUrl);
    IModuleMetadatasBuilder AddDependency(IModuleDependency dependency);
    IModuleMetadatasBuilder WithDependencies(IEnumerable<IModuleDependency> dependencies);
    IModuleMetadatasBuilder AddFile(string file);
    IModuleMetadatasBuilder WithFiles(IEnumerable<string> files);
    IModuleMetadatasBuilder WithIsSigned(bool isSigned);
    IModuleMetadatasBuilder WithSignatureNote(string signatureNote);
    IModuleMetadatas Build();
    IModuleMetadatasBuilder WithId(string id);
    IModuleMetadatasBuilder WithRequiredSignature(bool requiredSignature);
    IModuleMetadatasBuilder WithSignerFingerprint(string signerFingerprint);
    IModuleMetadatasBuilder WithSource(string source);
}
