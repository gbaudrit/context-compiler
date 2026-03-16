using static ContextCompiler.Modules.Abstractions.Configuration.ModuleLockFile;

namespace ContextCompiler.Modules.Abstractions.Configuration
{
    public static class Extensions
    {

        public static DependencyInfo ToDependencyInfo(this IModuleDependency moduleDependency)
        {
            return new DependencyInfo
            {
                Id = moduleDependency.Id,
                Version = moduleDependency.Version
            };
        }

        public static SignatureInfo ToSignatureInfo(this IModuleSignature moduleSignature)
        {
            return new SignatureInfo
            {
                Required = moduleSignature.Required,
                IsSigned = moduleSignature.IsSigned,
                SignerFingerprint = moduleSignature.SignerFingerprint,
                Note = moduleSignature.Note
            };
        }

        public static LockedModule ToLockedModule(this IModuleMetadatas moduleMetadatas)
        {
            return new LockedModule
            {
                Id = moduleMetadatas.Id,
                Version = new()
                {
                    Raw = moduleMetadatas.Version.Value
                },
                Source = moduleMetadatas.Source,
                Checksum = moduleMetadatas.Checksum,
                Files = moduleMetadatas.Files.ToList() ?? [],
                Dependencies = moduleMetadatas.Dependencies.Select(x => x.ToDependencyInfo()).ToList() ?? [],
                Signature = moduleMetadatas.Signature.ToSignatureInfo(),
                Authors = moduleMetadatas.Authors,
                RepositoryUrl = moduleMetadatas.RepositoryUrl?.ToString()
            };
        }

    }
}
