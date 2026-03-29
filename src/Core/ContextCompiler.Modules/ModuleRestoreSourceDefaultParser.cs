//using System.Diagnostics.CodeAnalysis;

//using ContextCompiler.Modules.Abstractions;

//namespace ContextCompiler.Modules;

//internal sealed class ModuleRestoreSourceDefaultParser(IModuleRestoreSourceBuilder moduleRestoreSourceBuilder) : IModuleRestoreSourceParser
//{
//    public bool TryParse(string packageId, [NotNullWhen(true)] out IModuleRestoreSource? moduleRestoreSource)
//    {
//        string id = "default";
//        if (packageId.Contains('@'))
//        {
//            id = packageId.Split('@').Last();
//        }

//        moduleRestoreSource = moduleRestoreSourceBuilder.InitNew()
//             .WithId(id)
//             .Build();
//        return true;
//    }
//}
