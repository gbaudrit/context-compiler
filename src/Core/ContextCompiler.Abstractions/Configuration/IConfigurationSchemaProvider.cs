
namespace ContextCompiler.Abstractions.Configuration
{
    public interface IConfigurationSchemaProvider
    {
        Task<IEnumerable<IConfigurationSchema>> GetSchemas();
    }
}
