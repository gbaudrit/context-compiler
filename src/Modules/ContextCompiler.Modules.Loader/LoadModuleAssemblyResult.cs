using System.Diagnostics.CodeAnalysis;

using ContextCompiler.Modules.Abstractions.Loading;

namespace ContextCompiler.Modules.Loader
{
    internal sealed record LoadModuleAssemblyResult : ILoadModuleAssemblyResult
    {
        [MemberNotNullWhen(false, nameof(ErrorMessage))]
        public required bool Success { get; init; }

        public string? ErrorMessage { get; init; }

        public required IEnumerable<Type> Types { get; init; }
    }
}
