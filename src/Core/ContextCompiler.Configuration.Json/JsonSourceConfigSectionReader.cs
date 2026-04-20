using System.Text.Json;

using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Sources;

namespace ContextCompiler.Configuration.Json
{
    internal sealed class JsonSourceConfigSectionReader : ISourceConfigSectionReader
    {
        public bool CanRead(ISourceConfigSection source, string key)
        {
            return source?.Options?.TryGetProperty(key, out _) ?? false;
        }

        public IResult<T> TryRead<T>(ISourceConfigSection section, string key)
        {
            if (section.Options is null)
            {
                return IResult.Failure<T>("Options are null");
            }

            JsonElement value = section.Options.Value;
            if (value.ValueKind != JsonValueKind.Object)
            {
                return IResult.Failure<T>("Options are not a JSON object");
            }
            else
            {
                if (!value.TryGetProperty(key, out JsonElement moduleSection))
                {
                    return IResult.Failure<T>($"Options do not contain a property with key '{key}'");
                }
                else
                {
                    T? o = moduleSection.Deserialize<T>();
                    return o == null
                        ? IResult.Failure<T>($"Failed to deserialize options with key '{key}' to type '{typeof(T).FullName}'")
                        : IResult.Success(o);
                }
            }
        }
    }
}
