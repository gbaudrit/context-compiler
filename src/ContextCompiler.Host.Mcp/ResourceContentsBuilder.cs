using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp;

internal sealed class ResourceContentsBuilder : IMCPResourceContentsBuilder
{

    private string? _uri;
    private string? _mimeType;
    private string? _text;

    public IMCPResourceContentsBuilder InitNew()
    {
        _uri = null;
        _mimeType = null;
        _text = null;
        return this;
    }

    public IMCPResourceContentsBuilder WithUri(string uri)
    {
        _uri = uri;
        return this;
    }

    public IMCPResourceContentsBuilder WithMimeType(string mimeType)
    {
        _mimeType = mimeType;
        return this;
    }

    public IMCPResourceContentsBuilder WithText(string text)
    {
        _text = text;
        return this;
    }

    public IMCPResourceContents Build()
    {
        return _uri is null
            ? throw new InvalidOperationException("Uri must be set")
            : _mimeType is null
            ? throw new InvalidOperationException("MimeType must be set")
            : _text is null ? (IMCPResourceContents)new ResourceContents() { MimeType = _mimeType, Uri = _uri } : new TextResourceContents() { MimeType = _mimeType, Text = _text, Uri = _uri };
    }

}
