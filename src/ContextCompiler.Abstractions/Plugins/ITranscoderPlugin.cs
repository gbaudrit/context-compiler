using ContextCompiler.Abstractions.Models;

namespace ContextCompiler.Abstractions.Plugins;

public interface ITranscoderPlugin : IPlugin
{
    bool CanTranscode(DataEnvelope envelope);
    Task<IReadOnlyList<TranscodedFragment>> TranscodeAsync(DataEnvelope envelope, SourceRef source, CancellationToken ct);
}

public sealed record TranscodedFragment(
    string Locator,
    string Content,
    IReadOnlyDictionary<string, string>? Tags = null
);
