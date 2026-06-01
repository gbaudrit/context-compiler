namespace ContextCompiler.Modules.Abstractions.Configuration;

public sealed class SecurityValidationConfig
{
    public bool Enabled { get; set; } = true;
    public bool BlockEvalExec { get; set; } = true;
    public bool BlockSystemCalls { get; set; }
    public bool BlockHardcodedSecrets { get; set; } = true;
    public bool WarnExternalUrls { get; set; } = true;
    public List<string> WhitelistedDomains { get; set; } =
    [
        "github.com",
        "githubusercontent.com",
        "anthropic.com",
        "microsoft.com"
    ];
}
