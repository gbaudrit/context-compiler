namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPResourceBuilder
{
    IMCPResource Build();
    IMCPResourceBuilder InitNew();
    IMCPResourceBuilder WithDescription(string description);
    IMCPResourceBuilder WithMimeType(string mimeType);
    IMCPResourceBuilder WithName(string name);
    IMCPResourceBuilder WithSize(long size);
    IMCPResourceBuilder WithTitle(string title);
    IMCPResourceBuilder WithUri(string uri);
}
