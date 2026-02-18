using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Configuration.Json
{
    internal sealed class CtxcConfigSerializer : ICtxcConfigSerializer
    {

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                // This modifier will suppress empty lists
                Modifiers = { IgnoreEmptyListOfStrings }
            }
        };

        public string Serialize(ICtxcConfig config)
        {
            return JsonSerializer.Serialize(config, JsonOptions);
        }

        private static void IgnoreEmptyListOfStrings(JsonTypeInfo typeInfo)
        {
            IEnumerable<JsonPropertyInfo> listOfStringProperties = typeInfo.Properties.Where(p => p.PropertyType == typeof(List<string>));

            foreach (JsonPropertyInfo propertyInfo in listOfStringProperties)
            {
                propertyInfo.ShouldSerialize = ShouldSerializeListOfString;
            }

            static bool ShouldSerializeListOfString(object _, object? value)
            {
                return ListOfStringNotNullOrEmpty(value as List<string>);
            }

            static bool ListOfStringNotNullOrEmpty(List<string>? list)
            {
                return list != null && list.Count != 0;
            }
        }

        public ICtxcConfig Deserialize(string json)
        {
            return JsonSerializer.Deserialize<CtxcConfig>(json, JsonOptions) ?? new CtxcConfig();
        }

    }
}
