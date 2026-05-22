using ContextCompiler.Abstractions.Output;
using ContextCompiler.Output.Modules.Artifacts.Registry.Models;

namespace ContextCompiler.Output.Modules.Artifacts.Registry.Extensions;

internal static class IOutputArtifactExtensions
{

    public static Artifact ToArtifact(this IOutputArtifact artifact)
    {
        return new Artifact()
        {
            StoreResource = artifact.StoreResource,
            Description = artifact.Description,
            GeneratedBy = artifact.GeneratedBy.FullName ?? "",
            MimeType = artifact.MimeType,
            Size = artifact.Size
        };
    }

}
