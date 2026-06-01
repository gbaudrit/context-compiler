namespace ContextCompiler.Abstractions.Configuration;

public interface IConstraintsInfo
{
    bool CanUseExternalSources { get; set; }
    List<string>? Must { get; set; }
    List<string>? MustNot { get; set; }
}
