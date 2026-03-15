namespace ContextCompiler.Modules.Abstractions.MCP;

public interface IMCPReadResourceResultBuilder
{

    IMCPReadResourceResultBuilder InitNew();

    IMCPReadResourceResultBuilder WithResourceContent(IMCPResourceContents content);

    IMCPReadResourceResult Build();

}
