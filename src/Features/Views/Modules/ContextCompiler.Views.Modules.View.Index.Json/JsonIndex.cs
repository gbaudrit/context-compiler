namespace ContextCompiler.Views.Modules.View.Index.Json;

internal sealed record JsonIndex
{
    public string ContractVersion { get; init; } = "1.0";
    public string ViewId { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public IReadOnlyList<JsonFragment> Fragments { get; init; } = [];
}

internal sealed record JsonFragment
{
    public string Ek { get; init; } = string.Empty;
    public string Er { get; init; } = string.Empty;
    public object Source { get; init; } = new { Path = string.Empty, Locator = string.Empty };
    public IReadOnlyList<Tag> Tags { get; init; } = [];
}

internal sealed record Tag
{
    public required string Name { get; init; }
    public required string Value { get; init; }
}
