using System.Diagnostics.CodeAnalysis;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Modules.Loader
{
    internal sealed record LoadModuleAssemblyResult : ILoadModuleAssemblyResult
    {
        [MemberNotNullWhen(true, nameof(ModuleType))]
        [MemberNotNullWhen(false, nameof(Success))]
        public required bool Success { get; init; }

        public string? ErrorMessage { get; init; }

        public required Type? ModuleType { get; init; }
    }
}
