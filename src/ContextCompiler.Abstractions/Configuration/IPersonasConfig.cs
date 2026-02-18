namespace ContextCompiler.Abstractions.Configuration;

public interface IPersonasConfig
{
    List<string> Active { get; set; }
    string Mode { get; set; }
    Dictionary<string, object>? Params { get; set; }
}
