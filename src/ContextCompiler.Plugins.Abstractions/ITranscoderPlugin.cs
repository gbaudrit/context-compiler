using ContextCompiler.Abstractions.Pipelines.Document;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Plugins.Abstractions;

public interface ITranscoderPlugin : IPlugin
{
    bool CanTranscode(IDataEnvelope envelope);
    Task<IReadOnlyList<TranscodedFragment>> TranscodeAsync(IDataEnvelope envelope, IDataPart dataPart, CancellationToken ct);
}

public sealed record TranscodedFragment(
    string Locator,
    string Content
) : ITranscodedFragment
{
    public IReadOnlyList<ITag> Tags { get; init; } = [];
};
