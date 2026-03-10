using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp;

internal sealed class MCPResourceBuilder : IMCPResourceBuilder
{

    private string? _name;
    private string? _title;
    private string? _uri;
    private string? _description;
    private string? _mimeType;
    private long? _size;

    public IMCPResourceBuilder InitNew()
    {
        _name = null;
        _title = null;
        _uri = null;
        _description = null;
        _mimeType = null;
        _size = null;
        return this;
    }

    public IMCPResourceBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMCPResourceBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public IMCPResourceBuilder WithUri(string uri)
    {
        _uri = uri;
        return this;
    }

    public IMCPResourceBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public IMCPResourceBuilder WithMimeType(string mimeType)
    {
        _mimeType = mimeType;
        return this;
    }

    public IMCPResourceBuilder WithSize(long size)
    {
        _size = size;
        return this;
    }

    public IMCPResource Build()
    {
        return new MCPResource
        {
            Name = _name ?? throw new InvalidOperationException("Name is not set"),
            Title = _title,
            Uri = _uri ?? throw new InvalidOperationException("Uri is not set"),
            Description = _description,
            MimeType = _mimeType,
            Size = _size
        };
    }

}
