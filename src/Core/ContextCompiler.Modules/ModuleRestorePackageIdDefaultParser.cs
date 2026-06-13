using System.Diagnostics.CodeAnalysis;

using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules;

internal sealed class ModuleRestorePackageIdDefaultParser(IModuleRestoreIdBuilder moduleRestoreIdBuilder, IModuleRestoreSourceBuilder moduleRestoreSourceBuilder) : IModuleRestorePackageIdParser
{
    public bool TryParse(string packageId, [NotNullWhen(true)] out IModuleRestoreId? moduleRestoreId)
    {
        string id = packageId;
        string sourceId = ModuleSourceIds.All;
        if (packageId.Contains('@'))
        {
            id = packageId.Split('@').First();
            sourceId = packageId.Split('@').Last();
        }

        moduleRestoreId = moduleRestoreIdBuilder.InitNew()
             .WithId(id)
             .WithSource(moduleRestoreSourceBuilder.InitNew()
                                                   .WithId(sourceId)
                                                   .Build())
             .WithChecksum(string.Empty)
             .Build();
        return true;
    }
}
