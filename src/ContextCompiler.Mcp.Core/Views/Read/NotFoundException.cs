namespace ContextCompiler.Mcp.Core.Views.Read
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Resource not found")
        {
        }
    }
}
