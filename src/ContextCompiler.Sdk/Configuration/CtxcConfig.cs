using System.Text.Json.Serialization;

namespace ContextCompiler.Sdk.Configuration;

public sealed class CtxcConfig
{
    [JsonPropertyName("excel")] public ExcelConfig? Excel { get; set; }
}

public sealed class ExcelConfig
{
    [JsonPropertyName("files")] public List<ExcelFileConfig> Files { get; set; } = new();
}

public sealed class ExcelFileConfig
{
    [JsonPropertyName("path")] public string Path { get; set; } = string.Empty;
    [JsonPropertyName("extracts")] public List<ExcelExtractConfig> Extracts { get; set; } = new();
}

public sealed class ExcelExtractConfig
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("sheet")] public string? Sheet { get; set; }
    [JsonPropertyName("table")] public string? Table { get; set; }
    [JsonPropertyName("range")] public string? Range { get; set; }
    [JsonPropertyName("columns")] public List<string>? Columns { get; set; }
    [JsonPropertyName("where")] public List<WhereClause>? Where { get; set; }
    [JsonPropertyName("rename")] public Dictionary<string,string>? Rename { get; set; }
    [JsonPropertyName("fragmentation")] public FragmentationStrategy Strategy { get; set; } = FragmentationStrategy.Single;
    [JsonPropertyName("chunkSize")] public int? ChunkSize { get; set; }
    [JsonPropertyName("groupBy")] public string? GroupBy { get; set; }
}

public enum FragmentationStrategy
{
#pragma warning disable CA1720 // Identifier contains type name
    Single,
#pragma warning restore CA1720 // Identifier contains type name
    Chunks,
    GroupBy
}

public sealed class WhereClause
{
    [JsonPropertyName("column")] public string Column { get; set; } = string.Empty;
    [JsonPropertyName("op")] public string Op { get; set; } = "=="; // ==, !=, contains, startsWith, endsWith
    [JsonPropertyName("value")] public string Value { get; set; } = string.Empty;
}
