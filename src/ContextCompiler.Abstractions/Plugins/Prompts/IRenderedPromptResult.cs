namespace ContextCompiler.Abstractions.Plugins.Prompts
{
    public interface IRenderedPromptResult
    {
        string RenderedText { get; init; }
        string Filename { get; init; }
    }
}
