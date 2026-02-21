
using System.Diagnostics.CodeAnalysis;

namespace ContextCompiler.Modules.Abstractions.Loading
{
    public interface ILoadModuleAssemblyResult
    {
        [MemberNotNullWhen(true, nameof(ModuleType))]
        [MemberNotNullWhen(false, nameof(Success))]
        bool Success { get; init; }

        string? ErrorMessage { get; init; }

        Type? ModuleType { get; init; }
    }
}
