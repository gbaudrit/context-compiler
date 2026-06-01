namespace ContextCompiler.Abstractions.Configuration;

public interface IOutputContract
{
    string? Format { get; set; }
    List<string>? Sections { get; set; }
    IOutputStyle? Style { get; set; }
}
