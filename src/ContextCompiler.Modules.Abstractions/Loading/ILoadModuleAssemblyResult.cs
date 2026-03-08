
using System.Diagnostics.CodeAnalysis;

namespace ContextCompiler.Modules.Abstractions.Loading
{
    public interface ILoadModuleAssemblyResult
    {
        [MemberNotNullWhen(false, nameof(Success))]
        bool Success { get; init; }

        string? ErrorMessage { get; init; }

        IEnumerable<Type> Types { get; init; }
    }
}
