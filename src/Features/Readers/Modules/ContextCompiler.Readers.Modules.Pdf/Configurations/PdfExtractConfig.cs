using System.Text.Json.Serialization;

namespace ContextCompiler.Readers.Modules.Pdf.Configurations
{
    internal sealed class PdfExtractsConfig
    {
        [JsonPropertyName("extracts")] public List<PdfExtractConfig> Extracts { get; set; } = [];
    }

    public sealed class PdfExtractConfig
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("start")] public int StartPage { get; set; }
        [JsonPropertyName("end")] public int EndPage { get; set; } = int.MaxValue;
        [JsonPropertyName("excludes")] public int[] PageExcludes { get; set; } = [];

        [JsonPropertyName("tags")] public string[] Tags { get; set; } = [];

        [JsonPropertyName("isArray")] public int[] IsArray { get; set; } = [];

    }
}
