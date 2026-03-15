using ContextCompiler.Modules.Abstractions.MCP;

namespace ContextCompiler.Host.Mcp
{
    internal sealed class ReadResourceResultBuilder : IMCPReadResourceResultBuilder
    {
        private List<IMCPResourceContents> _contents = [];

        public IMCPReadResourceResultBuilder InitNew()
        {
            _contents = [];
            return this;
        }

        public IMCPReadResourceResultBuilder WithResourceContent(IMCPResourceContents content)
        {
            _contents.Add(content);
            return this;
        }

        public IMCPReadResourceResult Build()
        {
            return new MCPReadResourceResult() { Contents = _contents.AsReadOnly() };
        }

    }
}
