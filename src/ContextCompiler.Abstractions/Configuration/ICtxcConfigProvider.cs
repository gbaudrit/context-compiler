namespace ContextCompiler.Abstractions.Configuration
{
    public interface ICtxcConfigProvider
    {
        ICtxcConfig Current { get; }

        ICtxcConfig GetConfigOrDefault(string? configPath);
    }
}
