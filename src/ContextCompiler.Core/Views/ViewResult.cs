using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Core.Views;

public sealed record ViewResult(
    string ViewId,
    string Title,
    string Filename,
    string Content,
    string Mime,
    IReadOnlyDictionary<string, string>? Metadata = null
) : IViewResult;
