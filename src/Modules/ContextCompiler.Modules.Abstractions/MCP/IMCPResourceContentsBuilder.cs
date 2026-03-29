namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPResourceContentsBuilder
{
    IMCPResourceContentsBuilder InitNew();
    IMCPResourceContentsBuilder WithUri(string uri);
    IMCPResourceContentsBuilder WithMimeType(string mimeType);
    IMCPResourceContentsBuilder WithText(string text);
    IMCPResourceContents Build();
}
