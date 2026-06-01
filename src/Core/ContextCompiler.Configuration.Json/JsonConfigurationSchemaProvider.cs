using System.Reflection;

using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Configuration.Json
{
    internal sealed class JsonConfigurationSchemaProvider : IConfigurationSchemaProvider
    {
        public Task<IEnumerable<IConfigurationSchema>> GetSchemas()
        {
            List<IConfigurationSchema> schemas = [];
            Assembly assembly = typeof(JsonConfigurationSchemaProvider).Assembly;
            string resourcePrefix = $"{assembly.GetName().Name}.Schemas.";
            foreach (string resourceName in assembly.GetManifestResourceNames())
            {
                Stream? resourceStream = assembly.GetManifestResourceStream(resourceName);
                if (resourceStream != null && resourceName.StartsWith(resourcePrefix, StringComparison.OrdinalIgnoreCase) && resourceName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                {
                    using StreamReader reader = new(resourceStream);
                    string content = reader.ReadToEnd();
                    string name = resourceName[resourcePrefix.Length..];
                    schemas.Add(new ConfigurationSchema { Name = name, Content = content });
                }
            }
            return Task.FromResult(schemas.AsEnumerable());
        }
    }
}
