namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPResourceContents
{
    string Uri { get; }
    string? MimeType { get; }
}

public interface IMCPTextResourceContents : IMCPResourceContents
{
    string Text { get; }
}
