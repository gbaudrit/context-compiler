using System.Diagnostics.CodeAnalysis;

using ContextCompiler.Plugins.Abstractions.Loading;

namespace ContextCompiler.Plugins.Loader
{
    internal sealed record LoadPluginAssemblyResult : ILoadPluginAssemblyResult
    {
        [MemberNotNullWhen(true, nameof(PluginType))]
        [MemberNotNullWhen(false, nameof(Success))]
        public required bool Success { get; init; }

        public string? ErrorMessage { get; init; }

        public required Type? PluginType { get; init; }
    }
}
