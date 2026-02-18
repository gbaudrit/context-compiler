
using System.Diagnostics.CodeAnalysis;

namespace ContextCompiler.Plugins.Abstractions.Loading
{
    public interface ILoadPluginAssemblyResult
    {
        [MemberNotNullWhen(true, nameof(PluginType))]
        [MemberNotNullWhen(false, nameof(Success))]
        bool Success { get; init; }

        string? ErrorMessage { get; init; }

        Type? PluginType { get; init; }
    }
}
