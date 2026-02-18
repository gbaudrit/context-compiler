namespace ContextCompiler.Abstractions.Configuration;

public interface IContextConfig
{
    bool Enabled { get; set; }
    string? Name { get; set; }
    string? Summary { get; set; }
    string? Domain { get; set; }
    Dictionary<string, string>? Audiences { get; set; }
    List<string>? Objectives { get; set; }
    List<string>? Assumptions { get; set; }
    IConstraintsInfo? Constraints { get; set; }
    Dictionary<string, string>? Glossary { get; set; }
    IOutputContract? OutputContract { get; set; }
}
