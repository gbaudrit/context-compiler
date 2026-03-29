namespace ContextCompiler.Abstractions.Configuration.Sections;

public interface IPersonasConfigSection
{
    List<string> Active { get; set; }
    string Mode { get; set; }
    Dictionary<string, object>? Params { get; set; }
}
