namespace ContextCompiler.Abstractions.Configuration.Sections;

public interface IContextConfigSection
{
    bool Enabled { get; set; }
    string? Name { get; set; }
    string? Summary { get; set; }
    string? Domain { get; set; }
    Dictionary<string, string>? Audiences { get; set; }
    List<string>? Objectives { get; set; }
    List<string>? Assumptions { get; set; }
    IConstraintsInfo? Constraints { get; }
    Dictionary<string, string>? Glossary { get; set; }
    IOutputContract? OutputContract { get; }
}
