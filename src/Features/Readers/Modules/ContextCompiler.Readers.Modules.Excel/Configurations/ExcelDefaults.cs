using System.Text.Json.Serialization;

namespace ContextCompiler.Readers.Modules.Excel.Configurations
{
    public sealed class ExcelDefaults
    {
        [JsonPropertyName("maxRows")] public int? MaxRows { get; set; }
        [JsonPropertyName("trimCells")] public bool? TrimCells { get; set; }
        [JsonPropertyName("emptyRowPolicy")] public string? EmptyRowPolicy { get; set; } // skip|keep
        [JsonPropertyName("header")] public HeaderDefaults? Header { get; set; }
    }
}
